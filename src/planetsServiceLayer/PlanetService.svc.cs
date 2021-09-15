using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DTO;

namespace planetsServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [Serializable]
    public class PlanetService : IPlanetService
    {
        Planets_BOLayer.PlanetRepository bo = new Planets_BOLayer.PlanetRepository();
       
        public string GetHottestPlanet(PlanetsInfo planetsData)
        {
            var hottestplanetName = bo.GetHottestStar(planetsData);
            return hottestplanetName;
        }

        public int GetOrphanPlanets(PlanetsInfo planetsData)
        {
            int NumofOrphanPlanets = 0;            
            NumofOrphanPlanets = bo.GetOrphanPlanets(planetsData);
            return NumofOrphanPlanets;
        }

        
       

       public PlanetsTimeline[] GetPlanetTimelineByYearandSize(PlanetsInfo planetdata)
        {
            var planetsByYearandSize = bo.GetPlanetTimeByYearandSize(planetdata);
            return planetsByYearandSize.ToArray();
        }
    }
}
