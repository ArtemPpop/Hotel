using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Model;

public partial class Booking:BaseClass
{
    [Key]
    private string? bookingId;
    public string? BookingId
    {
        get { return bookingId; }
        set
        {
            bookingId = value;
            OnPropertyChanged(nameof(BookingId));
        }
    }

    private string? guestId;
    public string? GuestId
    {
        get { return guestId; }
        set
        {
            guestId = value;
            OnPropertyChanged(nameof(GuestId));
        }
    }

    private string? roomId;
    public string? RoomId
    {
        get { return roomId; }
        set
        {
            roomId = value;
            OnPropertyChanged(nameof(RoomId));
        }
    }

    private string? checkInDate;
    public string? CheckInDate
    {
        get { return checkInDate; }
        set
        {
            checkInDate = value;
            OnPropertyChanged(nameof(CheckInDate));
        }
    }

    private string? checkOutDate;
    public string? CheckOutDate
    {
        get { return checkOutDate; }
        set
        {
            checkOutDate = value;
            OnPropertyChanged(nameof(CheckOutDate));
        }
    }

    public virtual Room Room { get; set; } = null!;
}
