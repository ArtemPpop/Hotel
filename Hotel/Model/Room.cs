using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Model;

public partial class Room:BaseClass
{
    [Key]
    public int RoomId { get; set; }

    private int roomNumber;
    public int RoomNumber
    {
        get { return roomNumber; }
        set
        {
            roomNumber = value;
            OnPropertyChanged(nameof(RoomNumber));
        }
    }

    private string? roomType;
    public string? RoomType
    {
        get { return roomType; }
        set
        {
            roomType = value;
            OnPropertyChanged(nameof(RoomType));
        }
    }

    private string? capacity;
    public string? Capacity
    {
        get { return capacity; }
        set
        {
            capacity = value;
            OnPropertyChanged(nameof(Capacity));
        }
    }

    private int pricePerNight;
    public int PricePerNight
    {
        get { return pricePerNight; }
        set
        {
            pricePerNight = value;
            OnPropertyChanged(nameof(PricePerNight));
        }
    }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
