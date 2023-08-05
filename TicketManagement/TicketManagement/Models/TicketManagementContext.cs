using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TicketManagement.Models;

public partial class TicketManagementContext : DbContext
{
    public TicketManagementContext()
    {
    }

    public TicketManagementContext(DbContextOptions<TicketManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<TicketCategory> TicketCategories { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;TrustServerCertificate=True;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__B611CB9D4E75115E");

            entity.ToTable("customer");

            entity.HasIndex(e => e.CustomerEmail, "UQ__customer__FFE82D72F3930636").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("customerEmail");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customerName");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__event__2DC7BD69D9FD964C");

            entity.ToTable("event");

            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.EventDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("eventDescription");
            entity.Property(e => e.EventEndDate)
                .HasColumnType("datetime")
                .HasColumnName("eventEndDate");
            entity.Property(e => e.EventName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("eventName");
            entity.Property(e => e.EventStartDate)
                .HasColumnType("datetime")
                .HasColumnName("eventStartDate");
            entity.Property(e => e.EventTypeId).HasColumnName("eventTypeID");
            entity.Property(e => e.VenueId).HasColumnName("venueID");

            entity.HasOne(d => d.EventType).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__event__eventType__0B91BA14");

            entity.HasOne(d => d.Venue).WithMany(p => p.Events)
                .HasForeignKey(d => d.VenueId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__event__venueID__0A9D95DB");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.EventTypeId).HasName("PK__eventTyp__04ACC49D60A45736");

            entity.ToTable("eventType");

            entity.HasIndex(e => e.EventTypeName, "UQ__eventTyp__F1C27EB1C9203B08").IsUnique();

            entity.Property(e => e.EventTypeId).HasColumnName("eventTypeID");
            entity.Property(e => e.EventTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("eventTypeName");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__0809337D6FD4A3FE");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.NumberOfTickets).HasColumnName("numberOfTickets");
            entity.Property(e => e.OrderedAt)
                .HasColumnType("datetime")
                .HasColumnName("orderedAt");
            entity.Property(e => e.TicketCategoryId).HasColumnName("ticketCategoryID");
            entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__orders__totalPri__114A936A");

            entity.HasOne(d => d.TicketCategory).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TicketCategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__orders__ticketCa__123EB7A3");
        });

        modelBuilder.Entity<TicketCategory>(entity =>
        {
            entity.HasKey(e => e.TicketCategoryId).HasName("PK__ticketCa__56F2E67A87CA9F8A");

            entity.ToTable("ticketCategory");

            entity.Property(e => e.TicketCategoryId).HasColumnName("ticketCategoryID");
            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.TicketCategoryDescription)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("ticketCategoryDescription");
            entity.Property(e => e.TicketCategoryPrice).HasColumnName("ticketCategoryPrice");

            entity.HasOne(d => d.Event).WithMany(p => p.TicketCategories)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ticketCat__event__0E6E26BF");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.VenueId).HasName("PK__venue__4DDFB71F7F9A8CE6");

            entity.ToTable("venue");

            entity.Property(e => e.VenueId).HasColumnName("venueID");
            entity.Property(e => e.VenueCapacity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("venueCapacity");
            entity.Property(e => e.VenueLocation)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("venueLocation");
            entity.Property(e => e.VenueType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("venueType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
