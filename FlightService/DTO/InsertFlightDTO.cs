namespace FlightService.DTO
{
    public class InsertFlightDTO
    {
        public string From { get; set; }
        public string To { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DaysOfWeek { get; set; }
    }
}
