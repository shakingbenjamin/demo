using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.LeaseSchedule
{
    public interface ILeaseScheduleResolver
    {
        List<LeaseScheduleDetailDto> ResolveDto(string json);
    }
}