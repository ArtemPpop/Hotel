using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Model;

public partial class HotelContext : DbContext
{
    public HotelContext()
    {
    }

    public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<GuestService> GuestServices { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=Hotel.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserId");
            entity.Property(e => e.UserName).HasColumnName("UserName");
            entity.Property(e => e.Password).HasColumnName("Password");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID ");
            entity.Property(e => e.FirstName).HasColumnName("FirstName ");
            entity.Property(e => e.HireDate).HasColumnName("HireDate ");
            entity.Property(e => e.LastName).HasColumnName("LastName ");
            entity.Property(e => e.Salary).HasColumnName("Salary ");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.ToTable("Guests ");

            entity.Property(e => e.GuestId).HasColumnName("GuestID ");
            entity.Property(e => e.FirstName).HasColumnName("FirstName ");
            entity.Property(e => e.LastName).HasColumnName("LastName ");
            entity.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber ");
        });

        modelBuilder.Entity<GuestService>(entity =>
        {
            entity.ToTable("GuestServices ");

            entity.Property(e => e.GuestServiceId).HasColumnName("GuestServiceID ");
            entity.Property(e => e.ReservationId).HasColumnName("ReservationID ");
            entity.Property(e => e.ServiceDate).HasColumnName("ServiceDate ");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID ");

        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payments ");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID ");
            entity.Property(e => e.AmountPaid).HasColumnName("AmountPaid ");
            entity.Property(e => e.PaymentDate).HasColumnName("PaymentDate ");
            entity.Property(e => e.ReservationId).HasColumnName("ReservationID ");

        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.ToTable("Reservations ");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID ");
            entity.Property(e => e.CheckInDate).HasColumnName("CheckInDate ");
            entity.Property(e => e.CheckOutDate).HasColumnName("CheckOutDate ");
            entity.Property(e => e.GuestId).HasColumnName("GuestID ");
            entity.Property(e => e.RoomId).HasColumnName("RoomID ");

        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Rooms ");

            entity.Property(e => e.RoomId).HasColumnName("RoomID ");
            entity.Property(e => e.Capacity).HasColumnName("Capacity ");
            entity.Property(e => e.PricePerNight).HasColumnName("PricePerNight ");
            entity.Property(e => e.RoomNumber).HasColumnName("RoomNumber ");
            entity.Property(e => e.RoomType).HasColumnName("RoomType ");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Services ");

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID ");
            entity.Property(e => e.ServiceName).HasColumnName("ServiceName ");
            entity.Property(e => e.ServicePrice).HasColumnName("ServicePrice ");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
