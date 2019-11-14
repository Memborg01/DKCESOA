using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SolutionAccelerator.DataServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICourseServuce" in both code and config file together.
    [ServiceContract]
    public interface ICourseService
    {
        [OperationContract]
        Course CreateCourse(string title);

        [OperationContract]
        IList<Course> AvailableCources();
    }
}
