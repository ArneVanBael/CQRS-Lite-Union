using CQRS_Lite_Union_API.Common.Entities;
using CQRS_Lite_Union_API.Common.Response;
using CQRS_Lite_Union_API.Domain.Attendees;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IResponse RegisterAttendee(Attendee attendee)
        {
            if (attendee == null) throw new ArgumentNullException(nameof(attendee));

            if (_attendees.Any(x => x.Email.ToLower().Equals(attendee.Email.ToLower())))
                return Response.Fail($"Already attendee with same email registered for this workshop", ErrorMessageType.Conflict);

            _attendees.Add(attendee);
            return Response.Ok();
        }

        public IResponse UnRegisterAttendee(Attendee attendee)
        {
            if(StartDate <= DateTime.Now)
                return Response.Fail($"Workshop has already started or passed, unregistering is not possible", ErrorMessageType.Conflict);

            _attendees.Remove(attendee);
            return Response.Ok();
        }
    }
}
