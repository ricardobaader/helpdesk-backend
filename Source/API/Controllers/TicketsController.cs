using API.DTOs.Requests;
using API.DTOs.Responses;
using Common.Application.Services.Tickets;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromForm] CreateTicketRequest request)
        {
            var ticketId = await _ticketsService.Create(request.ToCreateTicketDto());
            return Created(string.Empty, ticketId);
        }

        [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<ListTicketsResponse>> ListTickets([FromRoute] Guid userId)
        {
            var tickets = await _ticketsService.ListAllBy(userId);
            return Ok(tickets.Select(x => ListTicketsResponse.ToListTicketsResponse(x)));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> ListTicketDetails([FromRoute] Guid id)
        {
            var ticket = await _ticketsService.ListById(id);

            if (ticket is null)
                return NotFound(string.Empty);

            return Ok(ListTicketDetailsResponse.ToListTicketDetailsResponse(ticket));
        }

        [Authorize(Policy = "RequireSupportRole")]
        [HttpPut("{id}/user/{supportUserId}:start")]
        [SwaggerOperation("StartTicket")]
        public async Task<IActionResult> StartTicket([FromRoute] Guid id, Guid supportUserId)
        {
            await _ticketsService.Start(id, supportUserId);
            return Ok();
        }

        [Authorize(Policy = "RequireSupportRole")]
        [HttpPut("{id}/user/{supportUserId}:finish")]
        [SwaggerOperation("FinishTicket")]
        public async Task<IActionResult> FinishTicket([FromRoute] Guid id, [FromRoute] Guid supportUserId)
        {
            await _ticketsService.Finish(id, supportUserId);
            return Ok();
        }

        [Authorize]
        [HttpPut("{id}/user/{userId}:close")]
        [SwaggerOperation("CloseTicket")]
        public async Task<IActionResult> CloseTicket([FromRoute] Guid id, [FromRoute] Guid userId)
        {
            await _ticketsService.Close(id, userId);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}/user/{userId}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] Guid id, Guid userId)
        {
            await _ticketsService.Delete(id, userId);
            return Ok();
        }
    }
}