using CQRS_Lite_Union_API.Common.Entities;

namespace CQRS_Lite_Union_API.Domain.Attendees
{
    public class Attendee : Entity
    {
        public Attendee()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }

        public string FullName => FirstName + " " + LastName;
    }
}
