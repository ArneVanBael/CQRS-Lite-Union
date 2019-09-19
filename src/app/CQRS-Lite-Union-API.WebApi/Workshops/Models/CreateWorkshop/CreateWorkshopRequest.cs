using System;
using System.ComponentModel.DataAnnotations;

namespace CQRS_Lite_Union_API.WebApi.Workshops.Models.CreateWorkshop
{
    public class CreateWorkshopRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
