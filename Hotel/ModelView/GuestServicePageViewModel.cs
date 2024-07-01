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
    class GuestServicePageViewModel : BaseClass
    {
        HotelContext db = new HotelContext();
        private ObservableCollection<GuestService> guestServiceList;
        public ObservableCollection<GuestService> GuestServiceList
        {
            get { return guestServiceList; }
            set
            {
                guestServiceList = value;
                OnPropertyChanged(nameof(GuestServiceList));
            }
        }

        public GuestServicePage window;

        private GuestService? selectedGuestService;
        public GuestService? SelectedGuestService
        {
            get { return selectedGuestService; }
            set
            {
                selectedGuestService = value;
                OnPropertyChanged(nameof(SelectedGuestService));
            }
        }

        public GuestServicePageViewModel(GuestServicePage w)
        {
            this.window = w;
            db.Database.EnsureCreated();
            db.GuestServices.Load();
            GuestServiceList = db.GuestServices.Local.ToObservableCollection();
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        AddEditGuestService window = new AddEditGuestService(new GuestService());
                        if (window.ShowDialog() == true)
                        {
                            GuestService guestService = window.GuestService;
                            db.GuestServices.Add(guestService);
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
                        GuestService? guestService = obj as GuestService;
                        if (guestService == null) return;
                        AddEditGuestService window = new AddEditGuestService(guestService!);
                        if (window.ShowDialog() == true)
                        {
                            guestService.ServiceDate = window.GuestService.ServiceDate;
                            guestService.ReservationId = window.GuestService.ReservationId;
                            guestService.ServiceId = window.GuestService.ServiceId;
                            db.Entry(guestService).State = EntityState.Modified;
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

                      GuestService? guestService = selectedItem as GuestService;
                      if (guestService == null) return;

                      db.GuestServices.Remove(guestService);
                      db.SaveChanges();

                  }));
            }
        }
    }
}
