using API.DTOs.Requests;
using API.DTOs.Responses;
using Common.Application.Services.Tickets;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    public class TicketsController : BaseController
    {
        private readonly ITicketsService _ticketsService;

        public TicketsController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromForm] CreateTicketRequest request)
        {
            await _ticketsService.Create(request.ToCreateTicketDto());
            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<ListTicketsResponse>> ListTickets([FromRoute] Guid userId)
        {
            var tickets = await _ticketsService.ListAllBy(userId);
            return Ok(tickets.Select(x => ListTicketsResponse.ToListTicketsResponse(x)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ListTicketDetails([FromRoute] Guid id)
        {
            var ticket = await _ticketsService.ListById(id);
            return Ok(ListTicketsResponse.ToListTicketsResponse(ticket));
        }

        [HttpPut("{id}/user/{supportUserId}:start")]
        [SwaggerOperation("StartTicket")]
        public async Task<IActionResult> StartTicket([FromRoute] Guid id, Guid supportUserId)
        {
            await _ticketsService.Start(id, supportUserId);
            return Ok();
        }

        [HttpPut("{id}/user/{supportUserId}:finish")]
        [SwaggerOperation("FinishTicket")]
        public async Task<IActionResult> FinishTicket([FromRoute] Guid id, [FromRoute] Guid supportUserId)
        {
            await _ticketsService.Finish(id, supportUserId);
            return Ok();
        }

        [HttpPut("{id}/user/{userId}:close")]
        [SwaggerOperation("CloseTicket")]
        public async Task<IActionResult> CloseTicket([FromRoute] Guid id, [FromRoute] Guid userId)
        {
            await _ticketsService.Close(id, userId);
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