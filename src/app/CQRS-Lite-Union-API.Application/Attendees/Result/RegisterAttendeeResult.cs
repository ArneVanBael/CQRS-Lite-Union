using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Lite_Union_API.Application.Attendees.Result
{
    public class RegisterAttendeeResult
    {
        public RegisterAttendeeResult(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
