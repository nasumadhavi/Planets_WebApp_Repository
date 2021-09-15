using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Threading.Tasks;

using Planet_DTO;
using Planets_BOLayer;

namespace Planets_WebApp
{
    public partial class PlanetsPage : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "https://gist.githubusercontent.com/joelbirchler/66cf8045fcbb6515557347c05d789b4a/raw/9a196385b44d4288431eef74896c0512bad3defe/exoplanets";
            
            string json = ReadPlanetJsonInput(url);
            List<Planets> planetsJSONData = JsonConvert.DeserializeObject<List<Planets>>(json);

            PlanetsInfo planetInfo = new PlanetsInfo();
            planetInfo.planetlist = planetsJSONData;

            // PlanetModel dataModel = new PlanetModel();
            PlanetRepository planet_bo = new PlanetRepository();
            var numberofOrphanPlanets = planet_bo.GetOrphanPlanets(planetInfo);//dataModel.GetCountofOrphanPlanets(planetInfo);
            lblOrphanCount.Text = numberofOrphanPlanets.ToString();

            var hottestStar_PlanetIdentifier = planet_bo.GetHottestStar(planetInfo); ////dataModel.GetHottestPlanet(planetInfo);
            lblHottestStar.Text = hottestStar_PlanetIdentifier.ToString();

            var planetTimelineDataset = planet_bo.GetPlanetTimeByYearandSize(planetInfo);// dataModel.GetPlanetTimelineByYearandSize(planetInfo);
            gvPlanets.DataSource = planetTimelineDataset.ToList();
            gvPlanets.DataBind();

        }

        private int GetOrphanPlanets(List<Planets> array)
        {
            if(array.Count==0)
            {
                return 0;
            }
            var Countoforphansplanets = array.Where(t => t.TypeFlag == 3).Count();
            return Countoforphansplanets;
        }

        public string ReadPlanetJsonInput(string url)
        {
            //Uri uri = new Uri(url);
            //HttpClient client = new HttpClient();

            //var result = await client.GetAsync(url);
            ////eader(response.GetResponseStream());
            ////string output = reader.ReadToEnd();
            ////response.Close();

            //return result;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Get;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string output = reader.ReadToEnd();
            response.Close();
            return output;

        }
    }
}