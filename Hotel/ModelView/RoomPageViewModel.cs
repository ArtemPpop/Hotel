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
    internal class RoomPageViewModel : BaseClass
    {
        HotelContext db = new HotelContext();
        private ObservableCollection<Room> roomList;
        public ObservableCollection<Room> RoomList
        {
            get { return roomList; }
            set
            {
                roomList = value;
                OnPropertyChanged(nameof(RoomList));
            }
        }

        public RoomPage window;

        private Room? selectedroom;
        public Room? SelectedRoom
        {
            get { return selectedroom; }
            set
            {
                selectedroom = value;
                OnPropertyChanged(nameof(SelectedRoom));
            }
        }

        public RoomPageViewModel(RoomPage w)
        {
            this.window = w;
            db.Database.EnsureCreated();
            db.Rooms.Load();
            RoomList = db.Rooms.Local.ToObservableCollection();
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        AddEditRoom window = new AddEditRoom(new Room());
                        if (window.ShowDialog() == true)
                        {
                            Room room = window.Room;
                            db.Rooms.Add(room);
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
                        Room? room = obj as Room;
                        if (room == null) return;
                        AddEditRoom window = new AddEditRoom(room!);
                        if (window.ShowDialog() == true)
                        {
                            room.RoomNumber = window.Room.RoomNumber;
                            room.RoomType = window.Room.RoomType;
                            room.Capacity = window.Room.Capacity;
                            room.PricePerNight = window.Room.PricePerNight;
                            db.Entry(room).State = EntityState.Modified;
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
                      Room? room = selectedItem as Room;
                      if (room == null) return;

                      db.Rooms.Remove(room);
                      db.SaveChanges();

                  }));
            }
        }
    }
}