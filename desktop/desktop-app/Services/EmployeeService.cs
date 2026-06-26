using Hotel_erp_Winforms_App.Models;
using Microsoft.Data.SqlClient;
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
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HotelDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
        public List<Employee> LoadDgv(string query, Dictionary<string, object>? parameters = null)
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                if(parameters != null)
                {
                    foreach(var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
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
                            reader["password_hash"]?.ToString() ?? string.Empty,
                            reader["password_salt"]?.ToString() ?? string.Empty,
                            Convert.ToDateTime(reader["created_at"]),
                            Convert.ToDateTime(reader["updated_at"])
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
        public Employee GetEmployeeByTaxNumber(string taxNumber)
        {
            string query = "SELECT id, fname, lname, tax_number, paid_holidays_left, address, date_of_birth, date_of_hiring, " +
                "role, salary, password_hash, password_salt, created_at, updated_at " +
                "FROM employees " +
                "WHERE tax_number = @taxNumber";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@taxNumber", taxNumber);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
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
                                    reader["password_hash"]?.ToString() ?? string.Empty,
                                    reader["password_salt"]?.ToString() ?? string.Empty,
                                    Convert.ToDateTime(reader["created_at"]),
                                    Convert.ToDateTime(reader["updated_at"])
                                );
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Adatbázis hiba: " + ex.Message);
                    }
                }
            } return null;
        }
        public bool SaveEmployeesPassword(string taxNumber, string hashedPassword)
        {
            string query = "UPDATE employees SET password_hash = @passwordHash, password_salt = @passwordSalt, updated_at = GETDATE() WHERE " +
                "tax_number = @taxNumber";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@passwordHash", hashedPassword);
                    cmd.Parameters.AddWithValue("@passwordSalt", string.Empty);
                    cmd.Parameters.AddWithValue("@taxNumber", taxNumber);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Adatbázis hiba a mentés során: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }
        // jelszó kezelés vége
    }
}
