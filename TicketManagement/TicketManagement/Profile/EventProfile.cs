using TicketManagement.Models;
using TicketManagement.Models.DTO;

namespace TicketManagement.Profile;

public class EventProfile : AutoMapper.Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventDto>()
            .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.EventType!=null?src.EventType.EventTypeName:string.Empty))
            .ForMember(dest => dest.Venue, opt => opt.MapFrom(src => src.Venue))
            .ForMember(dest => dest.EventDescription, opt => opt.MapFrom(src => src.EventDescription))
            .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.EventName))
            .ForMember(dest => dest.EventStartDate, opt => opt.MapFrom(src => src.EventStartDate))
            .ForMember(dest => dest.EventEndDate, opt => opt.MapFrom(src => src.EventEndDate))
            .ForMember(dest => dest.TicketCategoryList, opt => opt.MapFrom(src => src.TicketCategories));
        CreateMap<Venue, VenueDto>();
        CreateMap<TicketCategory, TicketCategoryDto>();
        CreateMap<EventType, EventTypeDto>();
        CreateMap<Event, EventPatchDto>();
    }
}