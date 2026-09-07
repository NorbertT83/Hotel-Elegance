using Hotel_erp_Winforms_App.Models;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Web;

namespace Hotel_erp_Winforms_App.Services
{
    public class EmployeeService
    {
        private readonly string connectionString = DbConfig.ConnectionString;

        public async Task<List<Employee>> LoadDgvAsync(string query, Dictionary<string, object>? parameters = null)
        {
            List<Employee> employees = new List<Employee>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                await connection.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Employee employee = new Employee
                        (
                            Convert.ToInt32(reader["id"]),
                            reader["fname"]?.ToString() ?? string.Empty,
                            reader["lname"]?.ToString() ?? string.Empty,
                            reader["tax_number"]?.ToString() ?? string.Empty,
                            Convert.ToInt32(reader["paid_holidays_left"]),
                            reader["address"]?.ToString() ?? string.Empty,
                            Convert.ToDateTime(reader["date_of_birth"]),
                            Convert.ToDateTime(reader["date_of_hiring"]),
                            reader["role"]?.ToString() ?? string.Empty,
                            Convert.ToInt32(reader["salary"]),
                            Convert.ToDateTime(reader["created_at"]),
                            Convert.ToDateTime(reader["updated_at"]),
                            reader["email"]?.ToString() ?? string.Empty,
                            reader["password"]?.ToString() ?? string.Empty
                        );
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        public List<Employee> GetSortedEmployees(List<Employee> employees, string sortBy)
        {

            if (employees == null || !employees.Any()) return new List<Employee>();

            switch (sortBy)
            {
                case "Name": return employees.OrderBy(emp => emp.LName).ToList();
                case "JobTitle": return employees.OrderBy(emp => emp.JobTitle).ToList();
                default: return employees;
            }
        }

        // jelszó kezelés

        public async Task<Employee?> GetEmployeeByEmailAsync(string email)
        {
            string query = "SELECT id, fname, lname, tax_number, paid_holidays_left, address, date_of_birth, date_of_hiring, " +
                "role, salary, created_at, updated_at, email, password " +
                "FROM employees " +
                "WHERE email = @email";

            await using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);

                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Employee
                                (
                                    Convert.ToInt32(reader["id"]),
                                    reader["fname"]?.ToString() ?? string.Empty,
                                    reader["lname"]?.ToString() ?? string.Empty,
                                    reader["tax_number"]?.ToString() ?? string.Empty,
                                    Convert.ToInt32(reader["paid_holidays_left"]),
                                    reader["address"]?.ToString() ?? string.Empty,
                                    Convert.ToDateTime(reader["date_of_birth"]),
                                    Convert.ToDateTime(reader["date_of_hiring"]),
                                    reader["role"]?.ToString() ?? string.Empty,
                                    Convert.ToInt32(reader["salary"]),
                                    Convert.ToDateTime(reader["created_at"]),
                                    Convert.ToDateTime(reader["updated_at"]),
                                    reader["email"]?.ToString() ?? string.Empty,
                                    reader["password"]?.ToString() ?? string.Empty
                                );
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Adatbázis hiba: " + ex.Message);
                    }
                }
            }

            return null;
        }

        public async Task SaveNewBackofficeProfileAsync(string hashedPassword, string email, int id)
        {
            string query = @"
                UPDATE employees
                SET email = @email, password = @password
                WHERE id = @id";

            await using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                await using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@id", id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // --------------

        // UPDATE EMAIL
        public async Task UpdateEmailAsync(Employee employee, string email)
        {
            string query = @"
                UPDATE employees
                SET email = @email
                WHERE id = @id";

            await using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("id", employee.Id);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // DELTE EMPLYOEE FROM DB
        public void DeleteEmployee(Employee employee)
        {
            string query = "DELETE FROM employees WHERE tax_number = @taxNumber";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@taxNumber", employee.TaxNumber);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            
            catch(Exception ex)
            {
                MessageBox.Show($"An error occured while trying to delete from database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // GET EMAIL OF EMPLOYEE
        public async Task<string> GetEmployeesEmailAsync(Employee employee)
        {
            string query = @"
                SELECT email
                FROM employees
                WHERE id = @id";

            await using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                await using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", employee.Id);

                    object? result = await cmd.ExecuteScalarAsync();

                    return result != null ? result.ToString() : string.Empty;
                }
            }
        }

        #region helpers

        public async Task<bool> IsEmailAlreadyUsed(string email, EmployeeService _employeeService)
        {
            string query = "SELECT * FROM employees WHERE email = @email";
            var parameters = new Dictionary<string, object>
            {
                { "@email", email.Trim() }
            };

            List<Employee> list = await _employeeService.LoadDgvAsync(query, parameters);

            return list.Count > 0;
        }

        #endregion
    }
}
