using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Model;

public partial class GuestService:BaseClass
{
    [Key]
    private int guestServiceId;
    public int GuestServiceId
    {
        get { return guestServiceId; }
        set
        {
            guestServiceId = value;
            OnPropertyChanged(nameof(GuestServiceId));
        }
    }

    private string? reservationId;
    public string? ReservationId
    {
        get { return reservationId; }
        set
        {
            reservationId = value;
            OnPropertyChanged(nameof(ReservationId));
        }
    }


    private string? serviceId;
    public string? ServiceId
    {
        get { return serviceId; }
        set
        {
            serviceId = value;
            OnPropertyChanged(nameof(ServiceId));
        }
    }

    private string? serviceDate;
    public string? ServiceDate
    {
        get { return serviceDate; }
        set
        {
            serviceDate = value;
            OnPropertyChanged(nameof(ServiceDate));
        }
    }

    public virtual Reservation Reservation { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
