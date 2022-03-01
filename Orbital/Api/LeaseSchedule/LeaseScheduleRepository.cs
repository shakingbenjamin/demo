using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.LeaseSchedule
{
    public class LeaseScheduleRepository : ILeaseScheduleRepository
    {
        private readonly DataContext context;
        // add logging
        // full crud operations

        public LeaseScheduleRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<LeaseScheduleDetailDto>> GetAllLeaseSchedules()
        {
            try
            {
                var leaseSchedules = await context.LeaseSchedules
                    .Include(ls => ls.ScheduleEntry)
                    .ToListAsync();
                return leaseSchedules;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        // no functional stuff to add into the db but that would be next step 
        public void Add<T>(T entity) where T : class
        {
            try
            {
                context.Add(entity);
            }
            catch(Exception ex)
            {
                // log error
                throw;
            }
        }
    }
}