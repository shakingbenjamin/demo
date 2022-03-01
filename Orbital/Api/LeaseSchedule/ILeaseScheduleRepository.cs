using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.LeaseSchedule
{
    public interface ILeaseScheduleRepository
    {
        Task<List<LeaseScheduleDetailDto>> GetAllLeaseSchedules();

        // next step would be add CRUD behaviour
        void Add<T>(T entity) where T : class;
        // void Update<T>(T entity) where T : class;
        // void Delete<T>(T entity) where T : class;
    }
}