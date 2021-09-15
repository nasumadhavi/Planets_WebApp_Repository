using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet_DTO
{
    [Serializable]
    public class Planets
    {

        public string PlanetIdentifier { get; set; }
        public int? TypeFlag { get; set; }
        public double? PlanetaryMassJpt { get; set; }
        public double? RadiusJpt { get; set; }
        public double? PeriodDays { get; set; }
        public double? SemiMajorAxisAU { get; set; }
        public double? Eccentricity { get; set; }
        public double? PeriastronDeg { get; set; }
        public string LongitudeDeg { get; set; }
        public string AscendingNodeDeg { get; set; }
        public string InclinationDeg { get; set; }
        public double? SurfaceTempK { get; set; }
        public string AgeGyr { get; set; }
        public string DiscoveryMethod { get; set; }
        public int? DiscoveryYear { get; set; }
        public string LastUpdated { get; set; }
        public string RightAscension { get; set; }
        public string Declination { get; set; }
        public double? DistFromSunParsec { get; set; }
        public double? HostStarMassSlrMass { get; set; }
        public double? HostStarRadiusSlrRad { get; set; }
        public double? HostStarMetallicity { get; set; }
        public double? HostStarTempK { get; set; }
        public string HostStarAgeGyr { get; set; }
    }
    [Serializable]
    public class PlanetsInfo
    {
        public List<Planets> planetlist { get; set; }
        public bool Result { get; set; }
    }
}
