using Models;

namespace SolutionAccelerator.Migrations
{
    using Data_Access_Layer;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SolutionAcceleratorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SolutionAcceleratorContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var students = new List<Student>
            {
                new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
            var courses = new List<Course>
            {
                new Course{Title="Chemistry",Credits=3},
                new Course{Title="Microeconomics",Credits=3},
                new Course{Title="Macroeconomics",Credits=3},
                new Course{Title="Calculus",Credits=4},
                new Course{Title="Trigonometry",Credits=4},
                new Course{Title="Composition",Credits=3},
                new Course{Title="Literature",Credits=4}
            };
            courses.ForEach(s => context.Cources.Add(s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {

                new Enrollment{StudentID=1,Course=courses.First(c => c.Title.Equals("Chemistry")),Grade=Grade.A},
                new Enrollment{StudentID=1,Course=courses.First(c => c.Title.Equals("Microeconomics")),Grade=Grade.C},
                new Enrollment{StudentID=1,Course=courses.First(c => c.Title.Equals("Macroeconomics")),Grade=Grade.B},
                new Enrollment{StudentID=2,Course=courses.First(c => c.Title.Equals("Calculus")),Grade=Grade.B},
                new Enrollment{StudentID=2,Course=courses.First(c => c.Title.Equals("Trigonometry")),Grade=Grade.F},
                new Enrollment{StudentID=2,Course=courses.First(c => c.Title.Equals("Trigonometry")),Grade=Grade.F},
                new Enrollment{StudentID=3,Course=courses.First(c => c.Title.Equals("Composition"))},
                new Enrollment{StudentID=4,Course=courses.First(c => c.Title.Equals("Chemistry"))},
                new Enrollment{StudentID=4,Course=courses.First(c => c.Title.Equals("Microeconomics")),Grade=Grade.F},
                new Enrollment{StudentID=5,Course=courses.First(c => c.Title.Equals("Macroeconomics")),Grade=Grade.C},
                new Enrollment{StudentID=6,Course=courses.First(c => c.Title.Equals("Calculus"))},
                new Enrollment{StudentID=7,Course=courses.First(c => c.Title.Equals("Trigonometry")),Grade=Grade.A},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();

        }
    }
}
