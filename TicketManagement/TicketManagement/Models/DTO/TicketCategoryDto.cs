namespace TicketManagement.Models.DTO;

public class TicketCategoryDto
{
    public long TicketCategoryId { get; set; }
    public long? EventId { get; set; }
    public string? TicketCategoryDescription { get; set; }
    public double? TicketCategoryPrice { get; set; }
}