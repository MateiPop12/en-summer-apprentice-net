namespace TicketManagement.Models;

public partial class Venue
{
    public long VenueId { get; set; }

    public string? VenueLocation { get; set; }

    public string? VenueType { get; set; }

    public int? VenueCapacity { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
