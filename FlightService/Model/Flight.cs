namespace FlightService.Model
{
    public class Flight
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Capacity { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DaysOfWeek { get; set; }
    }
}
