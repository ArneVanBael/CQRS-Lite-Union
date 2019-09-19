using CQRS_Lite_Union_API.Domain.Attendees;
using CQRS_Lite_Union_API.Domain.Workshops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CQRS_Lite_Union_API.Application.Workshops.Result
{
    public class GetAttendeesOfWorkshopResult
    {
        public int WorkshopId { get; set; }
        public string WorkshopName { get; set; }
        public List<WorkshopAttendeeDTO> Attendees { get; set; }

        public static Expression<Func<Workshop, GetAttendeesOfWorkshopResult>> Projection
        {
            get
            {
                return x => new GetAttendeesOfWorkshopResult()
                {
                    WorkshopId = x.Id,
                    WorkshopName = x.Name,
                    Attendees = x.Attendees.AsQueryable().Select(WorkshopAttendeeDTO.Projection).ToList(),
                };
            }
        }
    }

    public sealed class WorkshopAttendeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public static Expression<Func<Attendee, WorkshopAttendeeDTO>> Projection
        {
            get
            {
                return x => new WorkshopAttendeeDTO
                {
                    Email = x.Email,
                    Id = x.Id,
                    Name = x.FirstName + " " + x.LastName
                };
            }
        }
    }
}
