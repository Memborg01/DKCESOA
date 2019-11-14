using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data_Access_Layer;
using Models;

namespace SolutionAccelerator.DataServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CourseServuce" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CourseServuce.svc or CourseServuce.svc.cs at the Solution Explorer and start debugging.
    public class CourseService : ICourseService
    {
        public IList<Course> AvailableCources()
        {
            using (SolutionAcceleratorContext context = new SolutionAcceleratorContext())
            {
                return context.Cources.ToList();
            }
        }

        public Course CreateCourse(string title)
        {
            var newCourse = new Course { Title = title };

            using (SolutionAcceleratorContext context = new SolutionAcceleratorContext())
            {
                var createdCourse = context.Cources.Add(newCourse);
                context.SaveChanges();
                return createdCourse;
            }
        }

    }
}
