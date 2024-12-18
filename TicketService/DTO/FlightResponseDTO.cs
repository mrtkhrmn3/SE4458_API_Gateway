namespace TicketService.DTO
{
    public class FlightResponseDTO
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DaysOfWeek { get; set; }
    }
}
