using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Model;

public partial class Payment:BaseClass
{
    [Key]
    private int paymentId;
    public int PaymentId
    {
        get { return paymentId; }
        set
        {
            paymentId = value;
            OnPropertyChanged(nameof(PaymentId));
        }
    }

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

    private string? paymentDate;
    public string? PaymentDate
    {
        get { return paymentDate; }
        set
        {
            paymentDate = value;
            OnPropertyChanged(nameof(PaymentDate));
        }
    }

    private string? amountPaid;
    public string? AmountPaid
    {
        get { return amountPaid; }
        set
        {
            amountPaid = value;
            OnPropertyChanged(nameof(AmountPaid));
        }
    }

    public virtual Reservation Reservation { get; set; } = null!;
}
