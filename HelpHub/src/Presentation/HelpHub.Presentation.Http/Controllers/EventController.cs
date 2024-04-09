using HelpHub.Application.Contracts.ServiceInterfaces;
using HelpHub.Application.Models.Event;
using Microsoft.AspNetCore.Mvc;

namespace HelpHub.Presentation.Http.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventModel>> Get(string eventId)
        {
            var eventModel = await _eventService.GetEvent(eventId);
            if (eventModel == null)
            {
                return NotFound();
            }

            return Ok(eventModel);
        }

        [HttpPut("{eventId}/name")]
        public async Task<ActionResult> UpdateName(string eventId, [FromBody] string newName)
        {
            var eventModel = await _eventService.GetEvent(eventId);
            if (eventModel == null)
            {
                return NotFound();
            }

            await _eventService.UpdateName(eventId, newName);
            return NoContent();
        }

        [HttpPut("{eventId}/location")]
        public async Task<ActionResult> UpdateLocation(string eventId, [FromBody] string newLocation)
        {
            var eventModel = await _eventService.GetEvent(eventId);
            if (eventModel == null)
            {
                return NotFound();
            }

            await _eventService.UpdateLocation(eventId, newLocation);
            return NoContent();
        }
    }
