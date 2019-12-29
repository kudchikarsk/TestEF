namespace TestEF.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestEF.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestEF.Models.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestEF.Models.ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var courses = new List<Course>()
            {
                new Course() { Name = "Foo" },
                new Course() { Name = "Bar" }
            };

            var students = new List<Student>()
            {
                new Student() { Name = "John Doe" },
                new Student() { Name = "Bob Doe" }
            };

            context.Students.AddOrUpdate(s=>s.Name, students.ToArray());
            context.SaveChanges();

            courses.ElementAt(0).Students.Add(students.ElementAt(0));
            courses.ElementAt(0).Students.Add(students.ElementAt(1));

            courses.ElementAt(1).Students.Add(students.ElementAt(0));
            context.Courses.AddOrUpdate(c => c.Name, courses.ToArray());
            context.SaveChanges();
        }
    }
}
