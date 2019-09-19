using System;

namespace CQRS_Lite_Union_API.WebApi.Workshops.Models.FindWorkshop
{
    public class FindWorkshopResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfAttendees { get; set; }
        public bool IsFullyBooked { get; set; }
    }
}
