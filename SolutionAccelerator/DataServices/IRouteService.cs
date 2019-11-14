using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;

namespace SolutionAccelerator.DataServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRouteService" in both code and config file together.
    [ServiceContract]
    public interface IRouteService
    {
        [OperationContract]
        IList<Route> AvailableRoutes(float weight, float length, float width, float height, string packageType);
    }
}
