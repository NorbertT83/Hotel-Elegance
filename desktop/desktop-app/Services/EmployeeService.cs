using Hotel_erp_Winforms_App.Models;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Hotel_erp_Winforms_App.Services
{
    public enum SaveOrUpdate
    {
        Save,
        Update
    }

    public class EmployeeService
    {
        #region variables

        private readonly string _connectionString = DbConfig.ConnectionString;

        #endregion

        #region Read Operations

        public async Task<List<Employee>> LoadDgvAsync(string query, Dictionary<string, object>? parameters = null)
        {
            var employees = new List<Employee>();

            await using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var employee = MapReaderToEmployee(reader);
                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
        }

        public async Task<Employee?> GetEmployeeByEmailAsync(string email)
        {
            const string query = @"
                SELECT id, fname, lname, tax_number, paid_holidays_left, address, date_of_birth, 
                       date_of_hiring, role, salary, created_at, updated_at, email, password
                FROM employees
                WHERE email = @email;";

            await using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);

                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapReaderToEmployee(reader);
                        }
                    }
                }
            }

            return null;
        }

        public async Task<string> GetEmployeesEmailAsync(Employee employee)
        {
            const string query = @"
                SELECT email
                FROM employees
                WHERE id = @id;";

            await using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", employee.Id);

                    object? result = await cmd.ExecuteScalarAsync();
                    return result?.ToString() ?? string.Empty;
                }
            }
        }

        public async Task<bool> IsEmailAlreadyUsedAsync(string email)
        {
            const string query = "SELECT COUNT(1) FROM employees WHERE email = @email;";

            await using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email.Trim());
                    long count = Convert.ToInt64(await cmd.ExecuteScalarAsync());
                    return count > 0;
                }
            }
        }

        #endregion

        #region Write / Update / Delete Operations

        public async Task SaveEmployeeToDbAsync(Employee emp, SaveOrUpdate saveOrUpdate)
        {
            const string saveQuery = @"
                INSERT INTO employees
                    (id, fname, lname, email, password, tax_number, paid_holidays_left, address, date_of_birth, date_of_hiring, role, salary, created_at, updated_at)
                VALUES
                    (@id, @fname, @lname, @email, @password, @tax_number, @holidays, @address, @date_of_birth, @date_of_hiring, @role, @salary, @created_at, @updated_at);";

            const string updateQuery = @"
                UPDATE employees
                SET 
                    fname = @fname, 
                    lname = @lname, 
                    email = @email, 
                    password = @password, 
                    tax_number = @tax_number, 
                    paid_holidays_left = @holidays, 
                    address = @address, 
                    date_of_birth = @date_of_birth, 
                    date_of_hiring = @date_of_hiring, 
                    role = @role, 
                    salary = @salary, 
                    created_at = @created_at, 
                    updated_at = @updated_at
                WHERE id = @id;";

            string query = saveOrUpdate == SaveOrUpdate.Save ? saveQuery : updateQuery;

            await using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", emp.Id);
                    cmd.Parameters.AddWithValue("@fname", emp.FName);
                    cmd.Parameters.AddWithValue("@lname", emp.LName);
                    cmd.Parameters.AddWithValue("@email", (object?)emp.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@password", (object?)emp.Password ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@tax_number", emp.TaxNumber);
                    cmd.Parameters.AddWithValue("@holidays", emp.PaidHolidaysLeft);
                    cmd.Parameters.AddWithValue("@address", emp.Address);
                    cmd.Parameters.AddWithValue("@date_of_birth", emp.DateOfBirth);
                    cmd.Parameters.AddWithValue("@date_of_hiring", emp.DateOfHiring);
                    cmd.Parameters.AddWithValue("@role", emp.JobTitle);
                    cmd.Parameters.AddWithValue("@salary", emp.Salary);
                    cmd.Parameters.AddWithValue("@created_at", emp.CreatedAt);
                    cmd.Parameters.AddWithValue("@updated_at", emp.UpdatedAt);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task SaveNewBackofficeProfileAsync(string hashedPassword, string email, int id)
        {
            const string query = @"
                UPDATE employees
                SET email = @email, password = @password
                WHERE id = @id;";

            await using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@id", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task SaveEmployeesNewPasswordAsync(Employee emp, string password)
        {
            const string query = @"
                UPDATE employees
                SET password = @password
                WHERE id = @id;";

            await using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@id", emp.Id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateEmailAsync(Employee employee, string email)
        {
            const string query = @"
                UPDATE employees
                SET email = @email
                WHERE id = @id;";

            await using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@id", employee.Id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteBackOfficeProfileAsync(Employee emp)
        {
            const string query = @"
                UPDATE employees
                SET password = NULL
                WHERE id = @id;";

            await using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", emp.Id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            const string query = "DELETE FROM employees WHERE tax_number = @taxNumber;";

            await using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@taxNumber", employee.TaxNumber);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        #endregion

        #region Business Logic & Helpers

        public List<Employee> GetSortedEmployees(List<Employee> employees, string sortBy)
        {
            if (employees == null || !employees.Any()) return new List<Employee>();

            return sortBy switch
            {
                "Name" => employees.OrderBy(emp => emp.LName).ToList(),
                "JobTitle" => employees.OrderBy(emp => emp.JobTitle).ToList(),
                _ => employees
            };
        }

        private static Employee MapReaderToEmployee(DbDataReader reader)
        {
            return new Employee(
                reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0,
                reader["fname"] != DBNull.Value ? reader["fname"].ToString()! : string.Empty,
                reader["lname"] != DBNull.Value ? reader["lname"].ToString()! : string.Empty,
                reader["tax_number"] != DBNull.Value ? reader["tax_number"].ToString()! : string.Empty,
                reader["paid_holidays_left"] != DBNull.Value ? Convert.ToInt32(reader["paid_holidays_left"]) : 0,
                reader["address"] != DBNull.Value ? reader["address"].ToString()! : string.Empty,
                reader["date_of_birth"] != DBNull.Value ? Convert.ToDateTime(reader["date_of_birth"]) : DateTime.MinValue,
                reader["date_of_hiring"] != DBNull.Value ? Convert.ToDateTime(reader["date_of_hiring"]) : DateTime.MinValue,
                reader["role"] != DBNull.Value ? reader["role"].ToString()! : string.Empty,
                reader["salary"] != DBNull.Value ? Convert.ToInt32(reader["salary"]) : 0,
                reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : DateTime.MinValue,
                reader["updated_at"] != DBNull.Value ? Convert.ToDateTime(reader["updated_at"]) : DateTime.MinValue,
                reader["email"] != DBNull.Value ? reader["email"].ToString()! : string.Empty,
                reader["password"] != DBNull.Value ? reader["password"].ToString()! : string.Empty
            );
        }

        #endregion
    }
}