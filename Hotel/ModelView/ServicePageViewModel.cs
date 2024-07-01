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
    class ServicePageViewModel : BaseClass
    {
        HotelContext db = new HotelContext();
        private ObservableCollection<Service> serviceList;
        public ObservableCollection<Service> ServiceList
        {
            get { return serviceList; }
            set
            {
                serviceList = value;
                OnPropertyChanged(nameof(ServiceList));
            }
        }

        public ServicePage window;

        private Service? selectedService;
        public Service? SelectedService
        {
            get { return selectedService; }
            set
            {
                selectedService = value;
                OnPropertyChanged(nameof(SelectedService));
            }
        }

        public ServicePageViewModel(ServicePage w)
        {
            this.window = w;
            db.Database.EnsureCreated();
            db.Services.Load();
            ServiceList = db.Services.Local.ToObservableCollection();
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        AddEditService window = new AddEditService(new Service());
                        if (window.ShowDialog() == true)
                        {
                            Service service = window.Service;
                            db.Services.Add(service);
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
                        Service? service = obj as Service;
                        if (service == null) return;
                        AddEditService window = new AddEditService(service!);
                        if (window.ShowDialog() == true)
                        {
                            service.ServiceName = window.Service.ServiceName;
                            service.ServicePrice = window.Service.ServicePrice;
                            db.Entry(service).State = EntityState.Modified;
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
                    
                      Service? service = selectedItem as Service;
                      if (service == null) return;

                      db.Services.Remove(service);
                      db.SaveChanges();

                  }));
            }
        }
    }
}


