using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;
using System.Data;

namespace finalProdjectDataBase
{
    internal class AdoCode
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=FiktivSkolaDatabase;Trusted_Connection=True;MultipleActiveResultSets=true";

        public void DisplayPersonalInformation()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Fname, Lname, Profession, HireDate FROM Personal";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        Console.WriteLine("Personal Overview:");
                        Console.WriteLine("------------------------------------------------------------");
                        Console.WriteLine("{0,-25} {1,-15} {2,-15} {3,-15}", "Name", "Profession", "Hire Date", "Years Months Days");
                        Console.WriteLine("------------------------------------------------------------");

                        while (reader.Read())
                        {
                            string Fname = reader["Fname"].ToString();
                            string Lname = reader["Lname"].ToString();
                            string Profession = reader["Profession"].ToString();
                            DateTime hireDate = Convert.ToDateTime(reader["HireDate"]);

                            TimeSpan duration = DateTime.Now - hireDate;

                            int years = duration.Days / 365;
                            int months = (duration.Days % 365) / 30;
                            int days = duration.Days % 30;

                            string fullName = $"{Fname} {Lname}";

                            string[] nameLines = fullName.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (var line in nameLines)
                            {
                                Console.WriteLine("{0,-25} {1,-15} {2,-15} {3,-15}", line, $"{Profession}", $"{hireDate:yyyy-MM-dd}", $"{years}y {months}m {days}d");
                            }
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }
        public void AddPersonalInformation()
        {
            Console.WriteLine("Adding Personal Information:");

            string firstName;
            while (true)
            {
                Console.Write("Enter First Name (up to 30 characters, no spaces): ");
                firstName = Console.ReadLine().Trim();

                if (!string.IsNullOrWhiteSpace(firstName) && firstName.Length <= 30 && !firstName.Contains(" "))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for First Name. Please enter a valid name without spaces, up to 30 characters.");
                }
            }

            string lastName;
            while (true)
            {
                Console.Write("Enter Last Name (up to 30 characters, no spaces): ");
                lastName = Console.ReadLine().Trim();

                if (!string.IsNullOrWhiteSpace(lastName) && lastName.Length <= 30 && !lastName.Contains(" "))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for Last Name. Please enter a valid name without spaces, up to 30 characters.");
                }
            }

            string[] validProfessions = { "Teacher", "Janitor", "Admin", "Principal" };
            string profession;
            while (true)
            {
                Console.Write("Enter Profession (Teacher/Janitor/Admin/Principal): ");
                profession = Console.ReadLine().Trim();

                if (validProfessions.Contains(profession))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for Profession. Please enter a valid profession (Teacher/Janitor/Admin/Principal).");
                }
            }

            decimal salary;
            while (true)
            {
                Console.Write("Enter Salary: ");
                if (decimal.TryParse(Console.ReadLine(), out salary) && salary >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for Salary. Please enter a non-negative number.");
                }
            }

            DateTime hireDate = DateTime.Now;

            InsertPersonalInformation(firstName, lastName, profession, salary, hireDate);
        }

        private void InsertPersonalInformation(string firstName, string lastName, string profession, decimal salary, DateTime hireDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Personal (Fname, Lname, Profession, Salary, HireDate) VALUES (@FirstName, @LastName, @Profession, @Salary, @HireDate); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Profession", profession);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@HireDate", hireDate);

                    try
                    {
                        connection.Open();
                        int personalID = Convert.ToInt32(command.ExecuteScalar());

                        if (personalID > 0)
                        {
                            Console.WriteLine($"Personal information added successfully! Personal ID: {personalID}");
                        }
                        else
                        {
                            Console.WriteLine("Error adding personal information.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }
        public void SaveStudent()
        {
            Console.WriteLine("Saving Student Information:");

            string firstName;
            while (true)
            {
                Console.Write("Enter Student's First Name (up to 30 characters, no spaces): ");
                firstName = Console.ReadLine().Trim();

                if (!string.IsNullOrWhiteSpace(firstName) && firstName.Length <= 30 && !firstName.Contains(" "))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for First Name. Please enter a valid name without spaces, up to 30 characters.");
                }
            }

            string lastName;
            while (true)
            {
                Console.Write("Enter Student's Last Name (up to 30 characters, no spaces): ");
                lastName = Console.ReadLine().Trim();

                if (!string.IsNullOrWhiteSpace(lastName) && lastName.Length <= 30 && !lastName.Contains(" "))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for Last Name. Please enter a valid name without spaces, up to 30 characters.");
                }
            }

            Console.Write("Enter Personal Identity Number: ");
            if (int.TryParse(Console.ReadLine(), out int personalIdentityNumber))
            {
                
            }
            else
            {
                Console.WriteLine("Invalid input for Personal Identity Number. Please enter a valid integer.");
                return; 
            }

            Console.Write("Enter Zip Code: ");
            if (int.TryParse(Console.ReadLine(), out int zipCode))
            {
                
            }
            else
            {
                Console.WriteLine("Invalid input for Zip Code. Please enter a valid integer.");
                return; 
            }

            Console.Write("Enter Street: ");
            string street = Console.ReadLine();

            Console.Write("Enter House Number: ");
            if (int.TryParse(Console.ReadLine(), out int houseNumber))
            {
                
            }
            else
            {
                Console.WriteLine("Invalid input for House Number. Please enter a valid integer.");
                return;
            }

            int classId;
            while (true)
            {
                Console.Write("Enter Class ID (1, 2, 3, 4, 5): ");
                if (int.TryParse(Console.ReadLine(), out classId) && classId >= 1 && classId <= 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for Class ID. Please enter a valid integer between 1 and 5.");
                }
            }

            InsertStudentInformation(firstName, lastName, personalIdentityNumber, zipCode, street, houseNumber, classId);
        }

        private void InsertStudentInformation(string firstName, string lastName, int personalIdentityNumber, int zipCode, string street, int houseNumber, int classId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Student (Fname, Lname, PersonalIdentityNumber, ZipCode, Street, HouseNumber, FkClass_Id) " +
                             "VALUES (@FirstName, @LastName, @PersonalIdentityNumber, @ZipCode, @Street, @HouseNumber, @ClassId)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@PersonalIdentityNumber", personalIdentityNumber);
                    command.Parameters.AddWithValue("@ZipCode", zipCode);
                    command.Parameters.AddWithValue("@Street", street);
                    command.Parameters.AddWithValue("@HouseNumber", houseNumber);
                    command.Parameters.AddWithValue("@ClassId", classId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Student information added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Error adding student information.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }
        public void SaveGrade()
        {
            Console.WriteLine("Saving Grade:");

            int studentId;
            while (true)
            {
                Console.Write("Enter Student ID: ");
                if (int.TryParse(Console.ReadLine(), out studentId) && studentId > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for Student ID. Please enter a positive integer.");
                }
            }

            int courseId;
            while (true)
            {
                Console.Write("Enter Course ID: ");
                if (int.TryParse(Console.ReadLine(), out courseId) && courseId > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for Course ID. Please enter a positive integer.");
                }
            }

            int teacherId;
            while (true)
            {
                Console.Write("Enter Teacher ID: ");
                if (int.TryParse(Console.ReadLine(), out teacherId) && teacherId > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for Teacher ID. Please enter a positive integer.");
                }
            }

            decimal courseGrade;
            while (true)
            {
                Console.Write("Enter Course Grade: ");
                if (decimal.TryParse(Console.ReadLine(), out courseGrade) && courseGrade >= 0 && courseGrade <= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for Course Grade. Please enter a valid decimal between 0 and 100.");
                }
            }

            DateTime courseDate;
            while (true)
            {
                Console.Write("Enter Course Date (YYYY-MM-DD): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out courseDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input for Course Date. Please enter a valid date in the format YYYY-MM-DD.");
                }
            }

            InsertGradeInformation(studentId, courseId, teacherId, courseGrade, courseDate);
        }

        private void InsertGradeInformation(int studentId, int courseId, int teacherId, decimal courseGrade, DateTime courseDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Course_Grade (FkStudent_Id, FkCourse_Id, FkTeacher_Id, CourseGrade, CourseDate) " +
                             "VALUES (@StudentId, @CourseId, @TeacherId, @CourseGrade, @CourseDate)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);
                    command.Parameters.AddWithValue("@CourseId", courseId);
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    command.Parameters.AddWithValue("@CourseGrade", courseGrade);
                    command.Parameters.AddWithValue("@CourseDate", courseDate);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Course Grade information added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Error adding Course Grade information.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }
        public void CalculateDepartmentPayout()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT D.Department_Id, D.Department_Name, SUM(P.Salary) AS TotalSalary " +
                             "FROM Department D " +
                             "JOIN Personal P ON D.Department_Id = P.FkDepartment_Id " +
                             "GROUP BY D.Department_Id, D.Department_Name";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        Console.WriteLine("Department Payout:");
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("{0,-20} {1,-15}", "Department", "Total Salary");
                        Console.WriteLine("-----------------------------");

                        while (reader.Read())
                        {
                            string departmentName = reader["Department_Name"].ToString();
                            decimal totalSalary = Convert.ToDecimal(reader["TotalSalary"]);

                            Console.WriteLine("{0,-20} {1,-15:C}", departmentName, totalSalary);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }
        public void CalculateDepartmentAverageSalary()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT D.Department_Name, AVG(P.Salary) AS AverageSalary " +
                             "FROM Department D " +
                             "JOIN Personal P ON D.Department_Id = P.FkDepartment_Id " +
                             "GROUP BY D.Department_Name";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        Console.WriteLine("Department Average Salary:");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("{0,-20} {1,-15}", "Department", "Average Salary");
                        Console.WriteLine("---------------------------------");

                        while (reader.Read())
                        {
                            string departmentName = reader["Department_Name"].ToString();
                            decimal averageSalary = Convert.ToDecimal(reader["AverageSalary"]);

                            Console.WriteLine("{0,-20} {1,-15:C}", departmentName, averageSalary);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }
        public int GetStudentIdFromUser()
        {
            Console.Write("Enter Student ID: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                return studentId;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for Student ID.");
                return 0;
            }
        }
        public void GetStudentInformation(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetStudentInformation", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Student_Id", studentId);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Console.WriteLine($"Student ID: {reader["Student_Id"]}");
                            Console.WriteLine($"First Name: {reader["Fname"]}");
                            Console.WriteLine($"Last Name: {reader["Lname"]}");
                            Console.WriteLine($"Personal Identity Number: {reader["PersonalIdentityNumber"]}");
                            Console.WriteLine($"Zip Code: {reader["ZipCode"]}");
                            Console.WriteLine($"Street: {reader["Street"]}");
                            Console.WriteLine($"House Number: {reader["Housenumber"]}");
                            Console.WriteLine($"Class ID: {reader["FkClassId"]}");
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }
        public int GetUserInput(string prompt)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return 0;
            }
        }
        public void DisplayGradesForStudent(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Course_Grades WHERE FkStudent_Id = @StudentId", connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);

                    try
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Console.WriteLine($"Course: {reader["FkCourse_Id"]}, Grade: {reader["CourseGrade"]}, Date: {reader["CourseDate"]}");
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }
        public void UpdateGradeForStudentWithTransaction(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        Console.WriteLine("Current Grades:");
                        DisplayGradesForStudent(studentId);

                        Console.WriteLine("Enter Course ID");
                        if (int.TryParse(Console.ReadLine(), out int courseId))
                        {
                            Console.WriteLine("New Grade");
                            string newGrade = Console.ReadLine();

                            using (SqlCommand command = new SqlCommand("UpdateGradeForStudent", connection, transaction))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                command.Parameters.AddWithValue("@StudentId", studentId);
                                command.Parameters.AddWithValue("@CourseId", courseId); 
                                command.Parameters.AddWithValue("@NewGrade", newGrade);

                                try
                                {
                                    command.ExecuteNonQuery();
                                    transaction.Commit();
                                    Console.WriteLine("Grade updated successfully!");
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    Console.WriteLine($"Error updating grade: {ex.Message}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for Course ID. Please enter a valid integer.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");

                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception rollbackEx)
                        {
                            Console.WriteLine($"Rollback Error: {rollbackEx.Message}");
                        }
                    }
                }
            }
        }
    }
}
