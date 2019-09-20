namespace CQRS_Lite_Union_API.Application.Attendees.Result
{
    public class AverageAttendeesPerWorkshopResult
    {
        public AverageAttendeesPerWorkshopResult(int totalWorkshops, int totalAttendees, int averagePerWorkshop)
        {
            TotalWorkshops = totalWorkshops;
            TotalAttendees = totalAttendees;
            AveragePerWorkshop = averagePerWorkshop;
        }

        public int TotalWorkshops { get; private set; }
        public int TotalAttendees { get; private set; }
        public int AveragePerWorkshop { get; private set; }
    }
}
