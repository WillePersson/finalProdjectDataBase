using finalProdjectDataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProdjectDataBase
{
    internal class EntityFramework
    {
        private readonly FiktivSkolaContext dbContext;

        public EntityFramework(FiktivSkolaContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void DisplayTeacherCountsByDepartment()
        {
            var departmentTeacherCounts = dbContext.Departments
                .Select(d => new
                {
                    DepartmentName = d.DepartmentName,
                    TeacherCount = d.Teachers.Count
                })
                .ToList();

            foreach (var result in departmentTeacherCounts)
            {
                Console.WriteLine($"Department: {result.DepartmentName}, Teachers Count: {result.TeacherCount}");
            }
        }
        public static void ViewAllStudents()
        {
            using (var dbContext = new FiktivSkolaContext())
            {
                try
                {
                    IQueryable<Student> studentsQuery = dbContext.Students.AsQueryable();

                    var allStudents = studentsQuery.ToList();

                    if (allStudents.Count > 0)
                    {
                        Console.WriteLine("All Students:");
                        foreach (var student in allStudents)
                        {
                            Console.WriteLine($"ID: {student.StudentId,-4} Name: {student.Fname} {student.Lname,-15} " +
                                $"Address: {student.Street} {student.Housenumber,-4}, " +
                                $"Personal Identity: {student.PersonalIdentityNumber,-10}, Class ID: {student.FkClassId}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No students found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public void ShowAllActiveCourses()
        {
            try
            {
                DateTime startOfNovember = new DateTime(2023, 11, 1);
                DateTime endOfNovember = new DateTime(2023, 11, 30);

                var activeCourses = dbContext.CourseGrades
                    .Where(cg => cg.CourseDate >= startOfNovember && cg.CourseDate <= endOfNovember)
                    .Select(cg => new
                    {
                        CourseName = cg.FkCourse.CourseName,
                        CourseDate = cg.CourseDate
                    })
                    .ToList();

                if (activeCourses.Count > 0)
                {
                    Console.WriteLine("Active Courses in November:");
                    foreach (var course in activeCourses)
                    {
                        Console.WriteLine($"Course: {course.CourseName,-20} Date: {course.CourseDate.ToShortDateString()}");
                    }
                }
                else
                {
                    Console.WriteLine("No active courses found in November.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
