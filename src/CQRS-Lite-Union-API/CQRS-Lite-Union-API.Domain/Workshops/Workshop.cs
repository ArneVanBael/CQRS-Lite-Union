using CQRS_Lite_Union_API.Common.Entities;
using CQRS_Lite_Union_API.Domain.Attendees;
using System;
using System.Collections.Generic;

namespace CQRS_Lite_Union_API.Domain.Workshops
{
    public class Workshop : Entity
    {
        private readonly List<Attendee> _attendees = new List<Attendee>();

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public IReadOnlyCollection<Attendee> Attendees => _attendees;

        public void RegisterAttendee(Attendee attendee)
        {
            if (attendee == null) return;
            _attendees.Add(attendee);
        }

        public void CancelRegistration()
        {
           
        }
    }
}
