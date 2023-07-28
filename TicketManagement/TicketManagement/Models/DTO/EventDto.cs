namespace TicketManagement.Models.DTO
{
    public class EventDto
    {
        public long EventId { get; set; }
        public string? Type { get; set; }
        public VenueDto? Venue { get; set; } 
        public string? EventDescription { get; set; }
        public string? EventName { get; set; }
        public DateTime? EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public List<TicketCategoryDto>? TicketCategoryList { get; set; }

    }
}
