using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Model;

public partial class Payment:BaseClass
{
    [Key]
    public int PaymentId { get; set; }

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

    private double? amountPaid;
    public double? AmountPaid
    {
        get { return amountPaid; }
        set
        {
            amountPaid = value;
            OnPropertyChanged(nameof(AmountPaid));
        }
    }

}
