using System.Collections.Generic;

namespace CQRS_Lite_Union_API.WebApi.Workshops.Models.GetAttendeesOfWorkshop
{
    public class GetAttendeesOfWorkshopResponse
    {
        public int WorkshopId { get; set; }
        public string WorkshopName { get; set; }
        public List<WorkshopAttendeeResponse> Attendees { get; set; }
    }

    public class WorkshopAttendeeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
