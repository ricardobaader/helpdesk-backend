using API.DTOs.Requests;
using API.DTOs.Responses;
using Common.Application.Services.Tickets;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService _ticketsService;

        public TicketsController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketRequest request)
        {
            await _ticketsService.Create(request.ToCreateTicketDto());
            return NoContent();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ListTicketsResponse>> ListTickets([FromRoute] Guid userId)
        {
            var tickets = await _ticketsService.ListTicketsBy(userId);
            return Ok(tickets.Select(x => ListTicketsResponse.ToListTicketsResponse(x)));
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> StartTicket([FromRoute] Guid id, [FromBody] Guid userId)
        {
            await _ticketsService.StartTicket(id, userId);
            return Ok();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> FinishTicket([FromRoute] Guid id, [FromBody] Guid userId)
        {
            await _ticketsService.FinishTicket(id, userId);
            return Ok();
        }
    }
}