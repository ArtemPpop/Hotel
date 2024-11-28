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
    public class ToPaymentConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Payment payment)
            {
                using (var db = new HotelContext())
                {
                    // Получаем резервацию по ReservationId
                    var reservation = db.Reservations.FirstOrDefault(r => r.ReservationId == payment.ReservationId);
                    if (reservation == null)
                        return "Unknown Reservation";

                    // Получаем гостя по GuestId из Reservation
                    var guest = db.Guests.FirstOrDefault(g => g.GuestId == reservation.GuestId);
                    string guestName = guest?.FirstName ?? "Unknown Guest";

                    // Формируем строку для отображения
                    return $"{guestName}";
                }
            }

            return "Invalid Payment";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}