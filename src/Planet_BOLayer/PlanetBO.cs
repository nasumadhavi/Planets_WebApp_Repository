using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planet_DTO;

namespace Planets_BOLayer
{
    public class PlanetRepository
    {
         public int GetOrphanPlanets(PlanetsInfo planetsData)
        {
            if (planetsData.planetlist.Count == 0)
            {
                return 0;
            }
            var Countoforphansplanets = planetsData.planetlist.Where(t => t.TypeFlag == 3).Count();
            return Countoforphansplanets;

        }
        public string GetHottestStar(PlanetsInfo planetsData)
        {
            var  planetsWithSurfaceTemp = planetsData.planetlist.Where(t => t.SurfaceTempK != null);
            var MaxHottesttemp = (from planet_data in planetsWithSurfaceTemp
                              select planet_data).Max(i => i.SurfaceTempK);
            var hottestStar = planetsData.planetlist.Where(p => p.SurfaceTempK == MaxHottesttemp).SingleOrDefault();
            return hottestStar.PlanetIdentifier;
        }
        public IEnumerable<PlanetsTimeline> GetPlanetTimeByYearandSize(PlanetsInfo planetsInfo)
        {
            var planettimeline_data = (from s in planetsInfo.planetlist
                                      group s by new { s.DiscoveryYear } into Y
                                        orderby Y.Key.DiscoveryYear ascending
                                      select new PlanetsTimeline
                                      {
                                          Year = Y.Key.DiscoveryYear,                             
                                          Small = Y.Where(p => p.RadiusJpt < 1).Count(),
                                          Medium = Y.Where(p => p.RadiusJpt > 1 && p.RadiusJpt < 2).Count(),
                                          Large = Y.Where(p => p.RadiusJpt >= 2).Count()
                                      });
            return planettimeline_data;
        }

        
        //string GetHottestPlanet(List<Planets> value);

        
        //PlanetsTimeline GetPlanetTimelineByYearandSize(List<Planets> value);
    }
}
