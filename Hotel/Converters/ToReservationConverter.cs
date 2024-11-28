using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Hotel.Converters
{
    public class ToReservationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Reservation reservation)
            {
                using (var db = new HotelContext())
                {
                    
                    var guest = db.Guests.FirstOrDefault(g => g.GuestId == reservation.GuestId);
                    string? guestName = guest?.FirstName;

                  
                    var room = db.Rooms.FirstOrDefault(r => r.RoomId == reservation.RoomId);
                    string? roomNumber = room?.RoomNumber.ToString();

                    return $"{guestName} - Room {roomNumber}";
                }
            }

            return "Invalid Reservation";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
