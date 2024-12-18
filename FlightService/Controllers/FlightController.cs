using FlightService.Context;
using FlightService.DTO;
using FlightService.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly FlightDbContext _context;

        public FlightController(FlightDbContext context)
        {
            _context = context;
        }

        [HttpPost("Insert-Flight")]
        public IActionResult InsertFlight([FromBody] InsertFlightDTO dto)
        {

            try
            {
                var flight = new Flight
                {
                    From = dto.From,
                    To = dto.To,
                    Capacity = dto.Capacity,
                    StartDate = dto.StartDate.Date,
                    EndDate = dto.EndDate.Date,
                    DaysOfWeek = dto.DaysOfWeek,
                    AvailableSeats = dto.Capacity

                };
                _context.Flights.Add(flight);
                _context.SaveChanges();

                return Ok(new { Status = "Successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Error", Description = ex.Message });
            }
        }

        [HttpGet("Report-Flights")]
        public IActionResult ReportFlights([FromQuery] ReportFlightDTO dto)
        {
            var flights = _context.Flights
                .Where(f => f.From == dto.From && f.To == dto.To &&
                            f.StartDate >= dto.StartDate && f.EndDate <= dto.EndDate)
                .Select(f => new FlightResponseDTO
                {
                    Id = f.Id,
                    From = f.From,
                    To = f.To,
                    AvailableSeats = f.AvailableSeats,
                    StartDate = f.StartDate,
                    EndDate = f.EndDate,
                    DaysOfWeek = f.DaysOfWeek
                })
                .Skip((dto.Page - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .ToList();
            return Ok(flights);
        }

        [HttpGet("Query-Flights")]
        public IActionResult QueryFlights([FromQuery] QueryFlightDTO dto)
        {
            var flights = _context.Flights
                .Where(f => f.From == dto.From && f.To == dto.To &&
                            f.StartDate <= dto.Date && f.EndDate >= dto.Date &&
                            f.AvailableSeats > 0)
                .Select(f => new FlightResponseDTO
                {
                    Id = f.Id,
                    From = f.From,
                    To = f.To,
                    AvailableSeats = f.AvailableSeats,
                    StartDate = f.StartDate,
                    EndDate = f.EndDate,
                    DaysOfWeek = f.DaysOfWeek
                })
                .Skip((dto.Page - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .ToList();

            return Ok(flights);
        }
    }
}
