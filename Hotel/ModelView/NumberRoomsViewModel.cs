using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Hotel.ModelView
{
    internal class NumberRoomsViewModel : BaseClass
    {
        private HotelContext db = new HotelContext();
        public ObservableCollection<Room> Rooms { get; set; }
        public ObservableCollection<Guest> Guests { get; set; }
        public ObservableCollection<Reservation> Reservations { get; set; }
        public ObservableCollection<Service> Services { get; set; }
        public ObservableCollection<Payment> Payments { get; set; }
        public ObservableCollection<string> Results { get; set; }

        public RelayCommand ShowRoomFundCommand { get; }
        public RelayCommand ShowCurrentGuestsCommand { get; }
        public RelayCommand ShowGuestInfoCommand { get; }
        public RelayCommand ShowGuestStayCostCommand { get; }
        public RelayCommand ShowTotalCostForPeriodCommand { get; }
        public RelayCommand ShowAvailableRoomsCommand { get; }
        public RelayCommand ShowRoomsAvailableInPeriodCommand { get; }
        public RelayCommand ShowBookedRoomsCommand { get; }
        public RelayCommand ShowDebtorGuestsCommand { get; }
        public RelayCommand ShowAllServicesCommand { get; }

        public NumberRoomsViewModel()
        {
            Rooms = new ObservableCollection<Room>();
            Guests = new ObservableCollection<Guest>();
            Reservations = new ObservableCollection<Reservation>();
            Services = new ObservableCollection<Service>();
            Payments = new ObservableCollection<Payment>();
            Results = new ObservableCollection<string>();

            // Инициализация команд
            ShowRoomFundCommand = new RelayCommand(_ => ShowRoomFund());
            ShowCurrentGuestsCommand = new RelayCommand(_ => ShowCurrentGuests());
            ShowGuestInfoCommand = new RelayCommand(_ => ShowGuestInfo());
            ShowGuestStayCostCommand = new RelayCommand(_ => ShowGuestStayCost());
            ShowTotalCostForPeriodCommand = new RelayCommand(_ => ShowTotalCostForPeriod());
            ShowAvailableRoomsCommand = new RelayCommand(_ => ShowAvailableRooms());
            ShowRoomsAvailableInPeriodCommand = new RelayCommand(_ => ShowRoomsAvailableInPeriod());
            ShowBookedRoomsCommand = new RelayCommand(_ => ShowBookedRooms());
            ShowDebtorGuestsCommand = new RelayCommand(_ => ShowDebtorGuests());
            ShowAllServicesCommand = new RelayCommand(_ => ShowAllServices());

            
        }

        private void ShowRoomFund()
        {
            Results.Clear(); 
            var roomInfoList = db.Rooms.ToList(); 

            foreach (var roomInfo in roomInfoList)
            {
                Results.Add($"Номер: {roomInfo.RoomNumber} Тип: {roomInfo.RoomType}");
            }
        }

        private void ShowCurrentGuests()
        {
                Results.Clear();
                var currentDate = DateTime.Now;
                var currentGuests = db.Reservations
                    .Where(r => r.CheckInDate <= currentDate && r.CheckOutDate >= currentDate)
                    .Join(db.Guests,
                          reservation => reservation.GuestId,
                          guest => guest.GuestId,
                          (reservation, guest) => new { Guest = guest, Reservation = reservation })
                    .Select(joinedItem => $"{joinedItem.Guest.FirstName} {joinedItem.Guest.LastName}")
                    .ToList();
                currentGuests.ForEach(guestName => Results.Add(guestName));

        }

        private void ShowGuestInfo()
        {
            Results.Clear();
            //  информаця о госте 
            var guestInfoList = db.Guests.ToList();

            foreach (var guestInfo in guestInfoList ) {
                Results.Add($"Имя: {guestInfo.FirstName} {guestInfo.LastName}");
                Results.Add($"Телефон: {guestInfo.PhoneNumber}");
            }
            
        }

        private void ShowGuestStayCost()
        {
            Results.Clear();
            foreach (var guest in db.Guests)
            {
                var reservation = db.Reservations.FirstOrDefault(r => r.GuestId == guest.GuestId);
                if (reservation != null)
                {
                    var room = db.Rooms.FirstOrDefault(r => r.RoomId == reservation.RoomId);
                    if (room != null)
                    {
                        var nights = (reservation.CheckOutDate - reservation.CheckInDate)?.Days ?? 0;
                        var cost = nights * room.PricePerNight;
                        Results.Add($"Стоимость для {guest.FirstName} {guest.LastName}: {cost}");
                    }
                }
            }
        }

        private void ShowTotalCostForPeriod()
        {
            var dateRangePicker = new DateRange();
            if (dateRangePicker.ShowDialog() == true)
            {
                var startDate = dateRangePicker.StartDate ?? DateTime.Now.AddDays(-7);
                var endDate = dateRangePicker.EndDate ?? DateTime.Now;

                Results.Clear();

                var totalCost = db.Reservations
                    .Where(r => r.CheckInDate >= startDate && r.CheckOutDate <= endDate)
                    .ToList()  
                    .Sum(r => {
                        var nights = (r.CheckOutDate - r.CheckInDate)?.Days ?? 0;
                        var pricePerNight = db.Rooms.FirstOrDefault(room => room.RoomId == r.RoomId)?.PricePerNight ?? 0;
                        return nights * pricePerNight;
                    });

                Results.Add($"Общая стоимость за период: {totalCost:C2}");
            }
        }

        private void ShowAvailableRooms()
        {
                 Results.Clear(); 
                 var currentDate = DateTime.Now;
                 var occupiedRooms = db.Reservations
                .Where(r => r.CheckInDate <= currentDate && r.CheckOutDate >= currentDate)
                .Select(r => r.RoomId)
                .ToList(); 
                var availableRooms = db.Rooms
                .Where(r => !occupiedRooms.Contains(r.RoomId))
                .Select(r => new { r.RoomNumber, r.RoomType, PricePerNight = r.PricePerNight.ToString("C2") })
                .ToList();

            availableRooms.ForEach(r => Results.Add($"Номер: {r.RoomNumber}, Тип: {r.RoomType}, Цена за ночь: {r.PricePerNight}"));
        }

        private void ShowRoomsAvailableInPeriod()
        {
            var dateRangePicker = new DateRange();
            if (dateRangePicker.ShowDialog() == true)
            {
                var startDate = dateRangePicker.StartDate ?? DateTime.Now;
                var endDate = dateRangePicker.EndDate ?? DateTime.Now.AddDays(7);

                Results.Clear();

                var occupiedRooms = db.Reservations
                    .Where(r => !(r.CheckOutDate <= startDate || r.CheckInDate >= endDate))
                    .Select(r => r.RoomId)
                    .ToList();

                var availableRooms = db.Rooms
                    .Where(r => !occupiedRooms.Contains(r.RoomId))
                    .Select(r => new { r.RoomNumber, r.RoomType, PricePerNight = r.PricePerNight.ToString("C2") })
                    .ToList();

                availableRooms.ForEach(r => Results.Add($"Номер: {r.RoomNumber}, Тип: {r.RoomType}, Цена за ночь: {r.PricePerNight}"));
            }
        }

        private void ShowBookedRooms()
        {
            Results.Clear();
            var allGuests = db.Guests
                .Join(db.Reservations, g => g.GuestId, r => r.GuestId, (g, r) => new { Guest = g, Reservation = r })
                .ToList();

            foreach (var entry in allGuests)
            {
                Results.Add($"Имя: {entry.Guest.FirstName}, Фамилия: {entry.Guest.LastName}, Номер бронирования: {entry.Reservation.ReservationId}");
            }

        }

        private void ShowDebtorGuests()
        {
            Results.Clear();
            var debtorGuests = db.Guests
                .AsEnumerable() 
                .Where(g => db.Reservations
                    .AsEnumerable() 
                    .Where(r => r.GuestId == g.GuestId)
                    .Any(r => db.Payments
                        .AsEnumerable() 
                        .Where(p => p.ReservationId == r.ReservationId)
                        .Sum(p => (double)p.AmountPaid) < db.Reservations
                        .AsEnumerable() 
                        .Where(res => res.ReservationId == r.ReservationId)
                        .Sum(res =>
                            (res.CheckOutDate.HasValue && res.CheckInDate.HasValue && db.Rooms.AsEnumerable().FirstOrDefault(room => room.RoomId == res.RoomId) != null)
                            ? (res.CheckOutDate.Value - res.CheckInDate.Value).TotalDays * (double)db.Rooms.AsEnumerable().FirstOrDefault(room => room.RoomId == res.RoomId).PricePerNight
                            : 0)))
                .Select(g => $"{g.FirstName} {g.LastName}")
                .ToList();

            debtorGuests.ForEach(g => Results.Add(g));
        }

        private void ShowAllServices()
        {
            Results.Clear();

            var allServices = db.Services
            .Select(s => $"{s.ServiceName}: {s.ServicePrice}") 
            .ToList();
            allServices.ForEach(s => Results.Add(s));
        }
    }
}