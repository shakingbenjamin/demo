using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Newtonsoft.Json;

namespace Api.LeaseSchedule
{
 public class LeaseScheduleResolver : ILeaseScheduleResolver
    {
        public List<LeaseScheduleDetailDto> ResolveDto(string json)
        {
            try
            {
                var leaseScheduleDeatilDtoList = new List<LeaseScheduleDetailDto>();
                var deserializedSchedules = JsonConvert.DeserializeObject<List<Root>>(json);
                var output = new List<string>();

                foreach (var d in deserializedSchedules)
                {
                    var dto = new LeaseScheduleDetailDto();
                    dto.ScheduleType = d.leaseschedule.scheduleType;
                    dto.ScheduleEntry = new List<ScheduleEntryDto>();

                    foreach (var se in d.leaseschedule.scheduleEntry)
                    {
                        foreach (var e in se.entryText)
                        {
                            if(string.IsNullOrEmpty(e))
                                break;
                                
                            var split = System.Text.RegularExpressions.Regex.Split(e, @"\s{2,}");
                            for (var i = 0; i < split.Length; i++)
                            {
                                if (string.IsNullOrEmpty(split[i]))
                                    break;
                                output.Add(split[i]);

                            }
                        }
                        var schedulEntryDto = new ScheduleEntryDto(se.entryNumber, se.entryDate, se.entryType, output.ToArray());
                        dto.ScheduleEntry.Add(schedulEntryDto);
                    }
                    leaseScheduleDeatilDtoList.Add(dto);
                }

                return leaseScheduleDeatilDtoList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }
    }
}