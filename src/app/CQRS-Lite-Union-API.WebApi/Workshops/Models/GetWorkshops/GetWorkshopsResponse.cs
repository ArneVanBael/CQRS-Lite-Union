using System;

namespace CQRS_Lite_Union_API.WebApi.Workshops.Models.GetWorkshops
{
    public class GetWorkshopsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
