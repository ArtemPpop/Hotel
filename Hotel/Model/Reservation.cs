using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Model;

public partial class Reservation:BaseClass
{
    [Key]
    private int reservationId;
    public int ReservationId
    {
        get { return reservationId; }
        set
        {
            reservationId = value;
            OnPropertyChanged(nameof(ReservationId));
        }
    }

    private int guestId;
    public int GuestId
    {
        get { return guestId; }
        set
        {
            guestId = value;
            OnPropertyChanged(nameof(GuestId));
        }
    }

    private int roomId;
    public int RoomId
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

    public virtual Guest Guest { get; set; } = null!;

    public virtual ICollection<GuestService> GuestServices { get; set; } = new List<GuestService>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Room Room { get; set; } = null!;
}
