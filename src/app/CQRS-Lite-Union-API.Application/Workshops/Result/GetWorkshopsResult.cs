using CQRS_Lite_Union_API.Domain.Workshops;
using System;
using System.Linq.Expressions;

namespace CQRS_Lite_Union_API.Application.Workshops.Result
{
    public class GetWorkshopsResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public static Expression<Func<Workshop, GetWorkshopsResult>> Projection
        {
            get
            {
                return x => new GetWorkshopsResult()
                {
                    Id = x.Id,
                    Name = x.Name,
                    EndDate = x.EndDate,
                    StartDate = x.StartDate
                };
            }
        }
    }
}
