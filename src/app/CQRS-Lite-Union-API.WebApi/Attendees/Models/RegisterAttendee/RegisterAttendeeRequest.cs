using System.ComponentModel.DataAnnotations;

namespace CQRS_Lite_Union_API.WebApi.Attendees.Models.RegisterAttendee
{
    public class RegisterAttendeeRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int WorkshopId { get; set; }
        public string Company { get; set; }
    }
}
