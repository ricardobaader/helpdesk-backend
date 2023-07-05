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
            var tickets = await _ticketsService.ListBy(userId);
            return Ok(tickets.Select(x => ListTicketsResponse.ToListTicketsResponse(x)));
        }

        [HttpPut("{id}/start/{userId}")]
        public async Task<IActionResult> StartTicket([FromRoute] Guid id, [FromRoute] Guid userId)
        {
            await _ticketsService.Start(id, userId);
            return Ok();
        }

        [HttpPut("{id}/finish/{userId}")]
        public async Task<IActionResult> FinishTicket([FromRoute] Guid id, [FromRoute] Guid userId)
        {
            await _ticketsService.Finish(id, userId);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] Guid id)
        {
            await _ticketsService.Delete(id);
            return Ok();
        }
    }
}