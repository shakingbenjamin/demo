using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.LeaseSchedule
{
       public class LeaseScheduleDetailDto
    {
        public Guid Id {get;set;}
        public string? ScheduleType {get;set;}
        public virtual ICollection<ScheduleEntryDto> ScheduleEntry {get;set;}
    }

    public class ScheduleEntryDto
    {
        public ScheduleEntryDto()
        {
            
        }
        public ScheduleEntryDto(string entryNumber, string entryDate, string entryType, string[] array)
        {
            this.Id = new Guid();
            this.EntryNumber = entryNumber;
            this.EntryDate = entryDate;
            this.EntryType = EntryType;
            this.RegistrationDate = $"{array[0]}";
            this.PlanningRef= $"{array[4]} {array[7]}";
            this.PropertyDescription = $"{array[1]} {array[5]}";
            this.LeaseTerm = $"{array[2]} {array[6]} {array[8]}";
            this.LesseeTitle = $"{array[3]}";
            this.Notes = string.Empty;
        }
        public Guid Id {get;set;}
        public string? EntryNumber {get;set;}
        public string? EntryDate { get; set; }
        public string? EntryType { get; set; }
        public string? RegistrationDate {get;set;}
        public string? PlanningRef {get;set;}
        public string? PropertyDescription {get;set;}
        public string? LeaseTerm {get;set;}
        public string? LesseeTitle {get;set;}
        public string? Notes {get;set;}
    }
}