namespace TicketManagement.Models.DTO;

public class EventPatchDto
{
    public long EventId { get; set; }
    public string EventName { get; set; } = string.Empty;
    public string EventDescription { get; set; }
    public string EventType { get; set; }
}