using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Api.LeaseSchedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data
{
    public class Seed
    {
        public static IConfiguration Configuration { get; set; }

        public static void SeedDatabase(DataContext context)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            try
            {
                // if DB isn't empty return from seed
                if (context.LeaseSchedules.Any())
                    return;

                var leaseSchedulesData = File.ReadAllText("Data/schedule_of_notices_of_lease_examples.json");
                var Resolver = new LeaseScheduleResolver();
                var scheduleDtoList = Resolver.ResolveDto(leaseSchedulesData);
                foreach (var dto in scheduleDtoList)
                {
                    context.Add(dto);
                }

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}