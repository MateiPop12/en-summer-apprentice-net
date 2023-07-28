using System;
using System.Collections.Generic;

namespace TicketManagement.Models;

public partial class Customer
{
    public long CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerEmail { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
