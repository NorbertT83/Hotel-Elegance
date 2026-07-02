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
        private readonly string connectionString = "Server=localhost;Database=hotelelegancedb;uid=root;pwd=";

        public List<Employee> LoadDgv(string query, Dictionary<string, object>? parameters = null)
        {
            List<Employee> employees = new List<Employee>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                if(parameters != null)
                {
                    foreach(var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                connection.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
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
                "role, salary, created_at, updated_at " +
                "FROM employees " +
                "WHERE tax_number = @taxNumber";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@taxNumber", taxNumber);

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
            using(MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using(MySqlCommand cmd = new MySqlCommand(query, conn))
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
    }
}
