using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Model;

public partial class Guest:BaseClass
{
    [Key]
    public int GuestId { get; set; }

    
    private string? firstName;
    public string? FirstName
    {
        get { return firstName; }
        set
        {
            firstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }

    private string? lastName;
    public string? LastName
    {
        get { return lastName; }
        set
        {
            lastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }

    private string? phoneNumber;
    internal DateTime CheckInDate;
    internal object Payments;
    internal DateTime CheckOutDate;
    internal object Room;

    public string? PhoneNumber
    {
        get { return phoneNumber; }
        set
        {
            phoneNumber = value;
            OnPropertyChanged(nameof(PhoneNumber));
        }
    }

  

}
