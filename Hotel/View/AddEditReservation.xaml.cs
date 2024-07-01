using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotel.View
{
    /// <summary>
    /// Логика взаимодействия для AddEditReservation.xaml
    /// </summary>
    public partial class AddEditReservation : Window
    {
        public Reservation Reservation { get; private set; }
        public AddEditReservation(Reservation reservation)
        {
            InitializeComponent();
            Reservation = reservation;
            DataContext = Reservation;
            using (HotelContext db = new HotelContext())
            {
                GuestId.ItemsSource = db.Guests.ToList();
            }
            using (HotelContext db = new HotelContext())
            {
                RoomId.ItemsSource = db.Rooms.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
