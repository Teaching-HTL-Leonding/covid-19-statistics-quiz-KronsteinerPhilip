using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaStatistics.Data
{
    public class FederalState
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<District> Districts { get; set; }
    }

    public class District
    {
        public int ID { get; set; }
        public FederalState State { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public List<CovidCases> CovidCases { get; set; }
    }

    public class CovidCases
    {
        public int ID { get; set; }
        public DateTime Date{ get; set; }
        public District District { get; set; }
        public int Population { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public bool Incidence { get; set; }
    }

}
