using System;
using System.Linq;
using LINQExample.DbOperations;
using LINQExample.Entities;

namespace LINQExample
{
   public class Program
    {
        public static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDBContext context = new LinqDBContext();
            var students = context.Students.ToList<Student>();

            Console.WriteLine("Find Students ");
            var findStudents = students.Where(s => s.StudentId == 1);
            var findStudent = context.Students.Find(1);
            Console.WriteLine("Find student: " + findStudent.StudentName);

            Console.WriteLine("First or Default");
            var firstOrDefault = students.FirstOrDefault(s => s.StudentId == 1);
            Console.WriteLine(firstOrDefault.StudentName);
        
             Console.WriteLine("Single or Default");
             var singleOrDefault = students.SingleOrDefault(s => s.StudentName == "Jane Doe");
             Console.WriteLine(singleOrDefault.ClassId);

            Console.WriteLine("Last or Default");
            var lastOrDefault = students.LastOrDefault(s => s.StudentId == 1);
            Console.WriteLine(lastOrDefault.StudentName);

            Console.WriteLine("To List");
            var toList = context.Students.Where(s => s.StudentId == 1).ToList();
            Console.WriteLine(toList.Count);

            Console.WriteLine("Count");
            var count = students.Count(s => s.StudentId == 1);
            Console.WriteLine(count);

            Console.WriteLine("Any");
            var any = students.Any(s => s.StudentId == 1);
            Console.WriteLine(any);

            Console.WriteLine("All");
            var all = students.All(s => s.StudentId == 1);
            Console.WriteLine(all);

            Console.WriteLine("Distinct");
            var distinct = students.Distinct();
            foreach (var item in distinct)
            {
                Console.WriteLine(item.StudentName);
            }

            Console.WriteLine("OrderBy");
            var orderBy = students.OrderBy(s => s.StudentName);
            foreach (var item in orderBy)
            {
                Console.WriteLine(item.StudentName);
            }

            Console.WriteLine("OrderByDescending");
            var orderByDescending = students.OrderByDescending(s => s.StudentName);
            foreach (var item in orderByDescending)
            {
                Console.WriteLine(item.StudentName);
            }

            Console.WriteLine("ThenBy");
            var thenBy = students.OrderBy(s => s.StudentName).ThenBy(s => s.StudentId);
            foreach (var item in thenBy)
            {
                Console.WriteLine(item.StudentName);
            }

            Console.WriteLine("ThenByDescending");
            var thenByDescending = students.OrderBy(s => s.StudentName).ThenByDescending(s => s.StudentId);
            foreach (var item in thenByDescending)
            {
                Console.WriteLine(item.StudentName);
            }

            Console.WriteLine("Skip");
            var skip = students.Skip(1);
            foreach (var item in skip)
            {
                Console.WriteLine(item.StudentName);
            }

            Console.WriteLine("SkipWhile");
            var skipWhile = students.SkipWhile(s => s.StudentId == 1);
            foreach (var item in skipWhile)
            {
                Console.WriteLine(item.StudentName);
            }

            Console.WriteLine("Take");
            var take = students.Take(1);
            foreach (var item in take)
            {
                Console.WriteLine(item.StudentName);
            }

            Console.WriteLine("TakeWhile");
            var takeWhile = students.TakeWhile(s => s.StudentId == 1);
            foreach (var item in takeWhile)
            {
                Console.WriteLine(item.StudentName);
            }

            Console.WriteLine("GroupBy");
            var groupBy = students.GroupBy(s => s.StudentName);
            foreach (var item in groupBy)
            {
                Console.WriteLine(item.Key);
            }

            Console.WriteLine("GroupBy with Select");
            var groupBySelect = students.GroupBy(s => s.StudentName).Select(s => s.Key);
            foreach (var item in groupBySelect)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("GroupBy with Select and Count");
            var groupBySelectCount = students.GroupBy(s => s.StudentName).Select(s => new { StudentName = s.Key, Count = s.Count() });
            foreach (var item in groupBySelectCount)
            {
                Console.WriteLine(item.StudentName + " " + item.Count);
            }

            Console.WriteLine("GroupBy with Select and Sum");
            var groupBySelectSum = students.GroupBy(s => s.StudentName).Select(s => new { StudentName = s.Key, Sum = s.Sum(x => x.StudentId) });
            foreach (var item in groupBySelectSum)
            {
                Console.WriteLine(item.StudentName + " " + item.Sum);
            }

            Console.WriteLine("GroupBy with Select and Average");
            var groupBySelectAverage = students.GroupBy(s => s.StudentName).Select(s => new { StudentName = s.Key, Average = s.Average(x => x.StudentId) });
            foreach (var item in groupBySelectAverage)
            {
                Console.WriteLine(item.StudentName + " " + item.Average);
            }

            Console.WriteLine("GroupBy with Select and Min");
            var groupBySelectMin = students.GroupBy(s => s.StudentName).Select(s => new { StudentName = s.Key, Min = s.Min(x => x.StudentId) });
            foreach (var item in groupBySelectMin)
            {
                Console.WriteLine(item.StudentName + " " + item.Min);
            }

            Console.WriteLine("GroupBy with Select and Max");
            var groupBySelectMax = students.GroupBy(s => s.StudentName).Select(s => new { StudentName = s.Key, Max = s.Max(x => x.StudentId) });
            foreach (var item in groupBySelectMax)
            {
                Console.WriteLine(item.StudentName + " " + item.Max);
            }

            Console.WriteLine("Anonymous Object Result");
            var anonymousObjectResult = context.Students.Where(s => s.ClassId == 1)
            .Select(s => new { StudentName = s.StudentName, CountryName = s.Country});

            foreach (var item in anonymousObjectResult) {
                Console.WriteLine(item.StudentName + " " + item.CountryName);
            }
        }
    }
     

}