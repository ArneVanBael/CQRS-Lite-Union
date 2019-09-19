using CQRS_Lite_Union_API.Domain.Workshops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CQRS_Lite_Union_API.Application.Workshops.Result
{
    public class GetWorkshopResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfAttendees { get; set; }
        public bool IsFullyBooked { get; set; }

        public static Expression<Func<Workshop, GetWorkshopResult>> Projection
        {
            get
            {
                return x => new GetWorkshopResult()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    NumberOfAttendees = x.Attendees.Count(),
                    IsFullyBooked = x.Attendees.Count() == 5,
                    EndDate = x.EndDate,
                    StartDate = x.StartDate
                };
            }
        }
    }
}
