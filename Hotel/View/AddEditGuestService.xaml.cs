﻿using Hotel.Model;
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
    /// Логика взаимодействия для AddEditGuestService.xaml
    /// </summary>
    public partial class AddEditGuestService : Window
    {
        public GuestService GuestService { get; private set; }
        public AddEditGuestService(GuestService guestService)
        {
            InitializeComponent();
            GuestService = guestService;
            DataContext = GuestService;
            using (HotelContext db = new HotelContext())
            {
                ReservationId.ItemsSource = db.Reservations.ToList();
            }
            using (HotelContext db = new HotelContext())
            {
                ServiceId.ItemsSource = db.Services.ToList();
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
