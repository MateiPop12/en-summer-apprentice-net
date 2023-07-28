using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.Models;
using TicketManagement.Models.DTO;
using TicketManagement.Repositories.RepositoryInterface;

namespace TicketManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        
        public EventController(IEventRepository eventRepository, IMapper mapper) 
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
        {
            var events = _eventRepository.GetAll();
            var eventsDto = _mapper.Map<List<EventDto>>(events);
            return Ok(eventsDto);
        }

        [HttpGet]
        public async Task<ActionResult<EventDto>> GetById(int id) {
            var @event =  await _eventRepository.GetById(id);
            var eventDto = _mapper.Map<EventDto>(@event);
            return Ok(eventDto);
        }

        [HttpPatch]
        public async Task<ActionResult<Event>> Patch(EventPatchDto eventPatch)
        {
            var eventEntity = await _eventRepository.GetById(eventPatch.EventId);
            _mapper.Map(eventPatch, eventEntity);
            _eventRepository.Update(eventEntity);
            return Ok(eventEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            var eventEntity = await _eventRepository.GetById(id);
            _eventRepository.Delete(eventEntity);
            return NoContent();
        }
        
    }
}
