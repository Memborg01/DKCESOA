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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RouteService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RouteService.svc or RouteService.svc.cs at the Solution Explorer and start debugging.
    public class RouteService : IRouteService
    {

        public IList<Route> AvailableRoutes(float weight, float length, float width, float height, string packageType)
        {
            using (SolutionAcceleratorContext context = new SolutionAcceleratorContext())
            {
                if (weight <= 20 && length <= 200)
                {
                    return context.Routes.ToList();
                }
                else
                {
                    return null;
                }
                   
            
            }
        }
    }
}
