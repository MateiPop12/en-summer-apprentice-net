namespace TicketManagement.Models.DTO;

public class VenueDto
{
    public long VenueId { get; set; }
    public string? VenueLocation { get; set; }
    public string? VenueType { get; set; }
    public int VenueCapacity { get; set; }
}