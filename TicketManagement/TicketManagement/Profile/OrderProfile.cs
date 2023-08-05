using TicketManagement.Models;
using TicketManagement.Models.DTO;

namespace TicketManagement.Profile;

public class OrderProfile : AutoMapper.Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.TicketCategory!.EventId))
            .ForMember(dest => dest.OrderedAt, opt => opt.MapFrom(src => src.OrderedAt))
            .ForMember(dest => dest.TicketCategoryId, opt => opt.MapFrom(src => src.TicketCategory!.TicketCategoryId))
            .ForMember(dest => dest.NumberOfTickets, opt => opt.MapFrom(src => src.NumberOfTickets))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice));
        CreateMap<OrderPatchDto, Order>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            .ForMember(dest => dest.TicketCategoryId, opt => opt.MapFrom(src=>src.TicketCategoryId))
            .ForMember(dest => dest.OrderedAt, opt => opt.MapFrom(src => src.OrderedAt))
            .ForMember(dest => dest.NumberOfTickets, opt=>opt.MapFrom(src=>src.NumberOfTickets));
        CreateMap<TicketCategory, TicketCategoryDto>();
    }
}