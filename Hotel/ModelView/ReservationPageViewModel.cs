using Hotel.Model;
using Hotel.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ModelView
{
    internal class ReservationPageViewModel : BaseClass
    {
        HotelContext db = new HotelContext();
        private ObservableCollection<Reservation> reservationList;
        public ObservableCollection<Reservation> ReservationList
        {
            get { return reservationList; }
            set
            {
                reservationList = value;
                OnPropertyChanged(nameof(ReservationList));
            }
        }

        public ReservationPage window;

        private Reservation? selectedReservation;
        public Reservation? SelectedReservation
        {
            get { return selectedReservation; }
            set
            {
                selectedReservation = value;
                OnPropertyChanged(nameof(SelectedReservation));
            }
        }

        public ReservationPageViewModel(ReservationPage w)
        {
            this.window = w;
            db.Database.EnsureCreated();
            db.Reservations.Load();
            ReservationList = db.Reservations.Local.ToObservableCollection();
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        AddEditReservation window = new AddEditReservation(new Reservation());
                        if (window.ShowDialog() == true)
                        {
                            Reservation reservation = window.Reservation;
                            db.Reservations.Add(reservation);
                            db.SaveChanges();
                        }
                    }));
            }
        }
        private RelayCommand? editCommand;
        public RelayCommand EditCommand
        {

            get
            {

                return editCommand ??
                    (editCommand = new RelayCommand(obj =>
                    {
                        Reservation? reservation = obj as Reservation;
                        if (reservation == null) return;
                        AddEditReservation window = new AddEditReservation(reservation!);
                        if (window.ShowDialog() == true)
                        {
                            reservation.CheckInDate = window.Reservation.CheckInDate;
                            reservation.CheckOutDate = window.Reservation.CheckOutDate;
                            reservation.GuestId = window.Reservation.GuestId;
                            reservation.RoomId = window.Reservation.RoomId;
                            db.Entry(reservation).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }));
            }
        }
        RelayCommand? deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(selectedItem =>
                  {
                     
                      Reservation? reservation = selectedItem as Reservation;
                      if (reservation == null) return;

                      db.Reservations.Remove(reservation);
                      db.SaveChanges();

                  }));
            }
        }
    }
}
