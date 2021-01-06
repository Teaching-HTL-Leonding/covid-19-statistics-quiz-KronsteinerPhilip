using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaStatistics.Data
{
    public class CoronaStatisticsDataContext : DbContext
    {
        public CoronaStatisticsDataContext(DbContextOptions<CoronaStatisticsDataContext> options) : base(options) { }
        public DbSet<FederalState> States { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<CovidCases> Cases { get; set; }
    }
}
