namespace TicketManagement.Models.DTO;

public class OrderDto
{
    public long EventId { get; set; }
    public DateTime OrderedAt { get; set; }
    public long TicketCategoryId { get; set; }
    public int NumberOfTickets { get; set; }
    public float TotalPrice { get; set; }
}