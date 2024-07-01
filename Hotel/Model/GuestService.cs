using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Model;

public partial class GuestService:BaseClass
{
    [Key]
    public int GuestServiceId { get; set; }

    private int? reservationId;
    public int? ReservationId
    {
        get { return reservationId; }
        set
        {
            reservationId = value;
            OnPropertyChanged(nameof(ReservationId));
        }
    }


    private int? serviceId;
    public int? ServiceId
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

}
