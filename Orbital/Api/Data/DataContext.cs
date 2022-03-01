using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.LeaseSchedule;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<LeaseScheduleDetailDto> LeaseSchedules {get;set;}
    }
}