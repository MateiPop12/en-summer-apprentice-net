using System;
using System.Collections.Generic;

namespace TicketManagement.Models;

public partial class Event
{
    public long EventId { get; set; }
    public long? VenueId { get; set; }
    public long? EventTypeId { get; set; }
    public string? EventDescription { get; set; }
    public string? EventName { get; set; }
    public DateTime? EventStartDate { get; set; }
    public DateTime? EventEndDate { get; set; }
    public virtual EventType? EventType { get; set; }
    public virtual List<TicketCategory>? TicketCategories { get; set; }
    public virtual Venue? Venue { get; set; }
}