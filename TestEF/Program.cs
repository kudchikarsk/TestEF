using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEF.Migrations;
using TestEF.Models;

namespace TestEF
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateDatabase();

            Using(new ApplicationContext(), (context) => {
                var students = context.Students
                .Include("Courses")
                .Where(s => s.Courses.Count() == 2)
                .ToList();
                
                var serializer = new YamlDotNet.Serialization.SerializerBuilder().Build();
                var yaml = serializer.Serialize(students);
                Console.WriteLine(yaml);
            });

            Console.ReadLine();
        }

        private static void UpdateDatabase()
        {
            var configuration = new Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        public static void Using<T> (T disposable, Action<T> action) where T : IDisposable
        {
            using (disposable)
            {
                action(disposable);
            }
        }
    }
}
