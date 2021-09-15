using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Planets_BOLayer;
using System.Collections.Generic;
using Planet_DTO;
using System.IO;

namespace Planets_UnitTestProject
{
    [TestClass]
    public class UnitTest_Planets
    {
        PlanetRepository planets_Repo = new PlanetRepository();
        PlanetsInfo planets = new PlanetsInfo();
        string planetsFile = "planets.json";
        List<Planets> planetsInputData;
        public UnitTest_Planets()
        {
            
            string jsonString = File.ReadAllText(planetsFile);
             planetsInputData = JsonConvert.DeserializeObject<List<Planets>>(jsonString);
            
        }
        [TestMethod]
        public void Test_GetHottestStar()
        {
            #region Arrange
            planets.planetlist = planetsInputData;
            #endregion
            #region Act 
            var hotteststarName = planets_Repo.GetHottestStar(planets);
            #endregion
            #region Assert
            Assert.AreEqual(hotteststarName, "Kepler-9 d");
            #endregion
        }
        [TestMethod]
        public void Test_GetCountofOrphanPlanets()
        {
            #region Arrange
            planets.planetlist = planetsInputData;
            #endregion
            #region Act 
            var countofOrphanPlanets_actualResult = planets_Repo.GetOrphanPlanets(planets);
            #endregion
            #region Assert
            Assert.AreEqual(countofOrphanPlanets_actualResult, 1);
            #endregion
        }

        [TestMethod]
        public void Test_GetPlanetTimeByYearandSize()
        {
            #region Arrange

            planets.planetlist = planetsInputData;
            #endregion
            #region Act 
            var planetTimelineData = planets_Repo.GetPlanetTimeByYearandSize(planets);
            List<PlanetsTimeline> list = new List<PlanetsTimeline>();
            foreach(PlanetsTimeline p in planetTimelineData)
            {
                list.Add(p);
            }
            PlanetsTimeline planetTimeLine_actualResult = list[0];
            #endregion
            #region Assert
            Assert.AreEqual(planetTimeLine_actualResult.Year, 2010);
            Assert.AreEqual(planetTimeLine_actualResult.Medium, 0);
            Assert.AreEqual(planetTimeLine_actualResult.Small, 2);
            Assert.AreEqual(planetTimeLine_actualResult.Large, 1);
            #endregion
        }
    }
}
