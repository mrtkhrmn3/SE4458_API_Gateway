namespace FlightService.DTO
{
    public class QueryFlightDTO
    {
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
