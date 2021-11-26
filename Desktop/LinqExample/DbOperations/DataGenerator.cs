using System.Linq;
using LINQExample.Entities;
using LINQExample.DbOperations;

namespace LINQExample
{
    public class DataGenerator{
        public static void Initialize()
        {
            using (var context = new LinqDBContext())
        {
            if (context.Students.Any())
            {
                return;
            }
            context.Students.AddRange(
                new Student
                {
                    
                    StudentName = "John Mary",
                    Age = 20,
                    Address = "123 Main Street",
                    City = "New York",
                    Country = "USA",
                    ClassId = 3
                },
                new Student
                {
                    
                    StudentName = "Jane Doe",
                    Age = 21,
                    Address = "456 Broadway",
                    City = "New Orleans",
                    Country = "USA",
                    ClassId = 2
                },
                new Student
                {
                    
                    StudentName = "Sam Smith",
                    Age = 19,
                    Address = "789 Broadway",
                    City = "California",
                    Country = "USA",
                    ClassId = 1
                }
            );
            context.SaveChanges();
        }
        }

    }
}