namespace TicketService.DTO
{
    public class BuyTicketDTO
    {
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string PassengerFullName { get; set; }
    }
}
