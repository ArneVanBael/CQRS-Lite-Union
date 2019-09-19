using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Lite_Union_API.Application.Workshops.Result
{
    public class CreateWorkshopResult
    {
        public CreateWorkshopResult(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
