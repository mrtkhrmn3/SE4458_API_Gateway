namespace TicketService.Model
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Guid FlightId { get; set; }
        public string PassengerFullName { get; set; }
        public bool IsCheckedIn { get; set; }
    }
}
