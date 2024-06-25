using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Model;

public partial class Service:BaseClass
{
    [Key]
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

    private string? serviceName;
    public string? ServiceName
    {
        get { return serviceName; }
        set
        {
            serviceName = value;
            OnPropertyChanged(nameof(ServiceName));
        }
    }

    private string? servicePrice;
    public string? ServicePrice
    {
        get { return servicePrice; }
        set
        {
            servicePrice = value;
            OnPropertyChanged(nameof(ServicePrice));
        }
    }

    public virtual ICollection<GuestService> GuestServices { get; set; } = new List<GuestService>();
}
