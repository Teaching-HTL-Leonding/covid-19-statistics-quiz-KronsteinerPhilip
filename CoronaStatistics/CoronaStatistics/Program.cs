using CoronaStatistics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaStatistics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //string[] linesDistricts = System.IO.File.ReadAllLines("polbezirke.csv");
            //foreach (var item in linesDistricts)
            //{
            //    Console.WriteLine(item);
            //}
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}