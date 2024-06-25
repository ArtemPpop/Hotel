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
         class GuestPageViewModel : BaseClass
        {
            HotelContext db = new HotelContext();
            private ObservableCollection<Guest> guestList;
            public ObservableCollection<Guest> GuestList
        {
                get { return guestList; }
                set
                {
                    guestList = value;
                    OnPropertyChanged(nameof(GuestList));
                }
            }

            public GuestPage window;

            private Guest? selectedGuest;
            public Guest? SelectedGuest
        {
                get { return selectedGuest; }
                set
                {
                    selectedGuest = value;
                    OnPropertyChanged(nameof(SelectedGuest));
                }
            }

            public GuestPageViewModel(GuestPage w)
            {
                this.window = w;
                db.Database.EnsureCreated();
                db.Guests.Load();
                GuestList = db.Guests.Local.ToObservableCollection();
            }

            private RelayCommand? addCommand;
            public RelayCommand AddCommand
            {
                get
                {
                    return addCommand ??
                        (addCommand = new RelayCommand(obj =>
                        {
                            AddEditGuest window = new AddEditGuest(new Guest());
                            if (window.ShowDialog() == true)
                            {
                                Guest guest = window.Guest;
                                db.Guests.Add(guest);
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
                       Guest? guest = obj as Guest;
                       if (guest == null) return;
                       AddEditGuest window = new AddEditGuest(guest!);
                       if (window.ShowDialog() == true)
                       {
                           guest.FirstName = window.Guest.FirstName;
                           guest.LastName = window.Guest.LastName;
                           guest.PhoneNumber = window.Guest.PhoneNumber;
                           db.Entry(guest).State = EntityState.Modified;
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
                          // получаем выделенный объект
                          Guest? guest = selectedItem as Guest;
                          if (guest == null) return;
                         
                              db.Guests.Remove(guest);
                              db.SaveChanges();
                          
                      }));
                }
            }
        }
    }


