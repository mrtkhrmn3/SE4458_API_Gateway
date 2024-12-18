using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicketService.Context;
using TicketService.DTO;
using TicketService.Model;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketDbContext _context;
        private readonly HttpClient _httpClient;
        private readonly string _flightServiceBaseUrl = "http://localhost:5293/api/flight";

        public TicketController(TicketDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        [HttpPost("Buy-Ticket")]
        public IActionResult BuyTicket([FromBody] BuyTicketDTO dto)
        {
            var response = _httpClient.GetAsync($"{_flightServiceBaseUrl}/Query-Flights?from={dto.From}&to={dto.To}&date={dto.Date:yyyy-MM-dd}&page=1&pageSize=10").Result;

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(new { Status = "Error", Description = "Flight not found." });
            }

            var flightJson = response.Content.ReadAsStringAsync().Result;
            var flights = JsonConvert.DeserializeObject<List<FlightResponseDTO>>(flightJson);

            if (flights == null || !flights.Any())
            {
                return BadRequest(new { Status = "Error", Description = "No flights found." });
            }

            var flight = flights.First();

            if (flight.AvailableSeats <= 0)
            {
                return BadRequest(new { Status = "Error", Description = "No available seats." });
            }

            flight.AvailableSeats--;

            var ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                FlightId = flight.Id,
                PassengerFullName = dto.PassengerFullName,
                IsCheckedIn = false
            };

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return Ok(new { Status = "Successful" });
        }


        [HttpPost("{ticketId}/Check-In")]
        public IActionResult CheckIn(Guid ticketId)
        {
            var ticket = _context.Tickets.Find(ticketId);

            if (ticket == null)
            {
                return BadRequest(new { Status = "Error", Description = "Ticket not found." });
            }

            ticket.IsCheckedIn = true;
            _context.SaveChanges();

            return Ok(new { Status = "Successful", Description = "Check-in completed successfully." });
        }
    }
}
