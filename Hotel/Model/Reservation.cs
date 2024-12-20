﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Model;

public partial class Reservation:BaseClass
{
    [Key]
     public int ReservationId { get; set; }

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

    private DateTime? checkInDate;
    public DateTime? CheckInDate
    {
        get { return checkInDate; }
        set
        {
            checkInDate = value;
            OnPropertyChanged(nameof(CheckInDate));
        }
    }

    private DateTime? checkOutDate;
    internal object RoomNumber;

    public DateTime? CheckOutDate
    {
        get { return checkOutDate; }
        set
        {
            checkOutDate = value;
            OnPropertyChanged(nameof(CheckOutDate));
        }
    }
}
