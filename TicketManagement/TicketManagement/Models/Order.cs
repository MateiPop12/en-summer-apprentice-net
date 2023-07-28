﻿using System;
using System.Collections.Generic;

namespace TicketManagement.Models;

public partial class Order
{
    public long OrderId { get; set; }

    public long? CustomerId { get; set; }

    public long? TicketCategoryId { get; set; }

    public DateTime? OrderedAt { get; set; }

    public int? NumberOfTickets { get; set; }

    public double? TotalPrice { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual TicketCategory? TicketCategory { get; set; }
}
