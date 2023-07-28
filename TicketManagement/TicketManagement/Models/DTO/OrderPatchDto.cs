namespace TicketManagement.Models.DTO;

public class OrderPatchDto
{
    public long OrderId { get; set; }
    public long TicketCategoryId { get; set; }
    public DateTime OrderedAt { get; set; }
    public int NumberOfTickets { get; set; }
}