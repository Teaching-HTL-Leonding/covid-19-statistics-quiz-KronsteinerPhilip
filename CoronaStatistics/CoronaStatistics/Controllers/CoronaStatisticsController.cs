using CoronaStatistics.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace CoronaStatistics.Controllers
{
    [ApiController]
    [Route("/api")]
    public class CoronaStatisticsController : ControllerBase
    {
        private readonly CoronaStatisticsDataContext context;

        public CoronaStatisticsController(CoronaStatisticsDataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/state")]
        public IEnumerable<FederalState> GetStates() => context.States;
        
        [HttpGet]
        [Route("/state/{id}/cases")]
        public List<District> GetCertainState(int id)
        {
            List<CovidCases> cases = new List<CovidCases>();
            var districts = context.States.FirstOrDefault(s => s.ID == id).Districts;
            return districts;
        }

        [HttpPost]
        public async void AddCase ([FromBody] CovidCases newCase)
        {
            context.Add(newCase);
            await context.SaveChangesAsync();
        }

        [HttpGet]
        [Route("/importData")]
        public async void importData()
        {
            string[] linesDistricts = System.IO.File.ReadAllLines("polbezirke.csv");
            string[] linesCases = System.IO.File.ReadAllLines("CovidFaelle_GKZ.csv");

            for (int i = 3; i < linesDistricts.Length-24; i++)
            {
                string[] partsDistricts = linesDistricts[i].Split(";");
                string[] partsCases = linesCases[i-2].Split(";");
                FederalState fs = new FederalState { ID = Int32.Parse(partsDistricts[0]), Name = partsDistricts[1]};
                if (!context.States.Contains(fs))
                    context.Add(fs);
                List<CovidCases> cases = new List<CovidCases>();
                District ds = new District { ID = Int32.Parse(partsDistricts[2]), Name = partsDistricts[3], Code = Int32.Parse(partsDistricts[4]), State = fs };
                cases.Add(new CovidCases { Date = new DateTime(2021, 1, 6), District = ds, Population = Int32.Parse(partsCases[2]), Cases = Int32.Parse(partsCases[3]), Deaths = Int32.Parse(partsCases[4])});
                ds.CovidCases = cases;
                if (!context.Districts.Contains(ds))
                    context.Add(ds);
                await context.SaveChangesAsync();
            }
        }
    }
}
