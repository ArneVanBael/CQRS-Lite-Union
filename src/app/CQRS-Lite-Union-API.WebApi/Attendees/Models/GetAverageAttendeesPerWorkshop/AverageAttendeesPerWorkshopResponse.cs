using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.WebApi.Attendees.Models.GetAverageAttendeesPerWorkshop
{
    public class AverageAttendeesPerWorkshopResponse
    {
        public int TotalWorkshops { get; set; }
        public int TotalAttendees { get; set; }
        public int AveragePerWorkshop { get; set; }
    }
}
