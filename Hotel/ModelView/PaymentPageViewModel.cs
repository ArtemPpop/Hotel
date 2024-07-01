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
    internal class PaymentPageViewModel : BaseClass 
    { 
     HotelContext db = new HotelContext();
    private ObservableCollection<Payment> paymentList;
    public ObservableCollection<Payment> PaymentList
        {
        get { return paymentList; }
        set
        {
                paymentList = value;
            OnPropertyChanged(nameof(PaymentList));
        }
    }

    public PaymentPage window;

    private Payment? selectedPayment;
    public Payment? SelectedPayment
        {
        get { return selectedPayment; }
        set
        {
                selectedPayment = value;
            OnPropertyChanged(nameof(SelectedPayment));
        }
    }

    public PaymentPageViewModel(PaymentPage w)
    {
        this.window = w;
        db.Database.EnsureCreated();
        db.Payments.Load();
            PaymentList = db.Payments.Local.ToObservableCollection();
    }

    private RelayCommand? addCommand;
    public RelayCommand AddCommand
    {
        get
        {
            return addCommand ??
                (addCommand = new RelayCommand(obj =>
                {
                    AddEditPayment window = new AddEditPayment(new Payment());
                    if (window.ShowDialog() == true)
                    {
                        Payment payment = window.Payment;
                        db.Payments.Add(payment);
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
                    Payment? payment = obj as Payment;
                    if (payment == null) return;
                    AddEditPayment window = new AddEditPayment(payment!);
                    if (window.ShowDialog() == true)
                    {
                        payment.PaymentDate = window.Payment.PaymentDate;
                        payment.AmountPaid = window.Payment.AmountPaid; 
                        payment.ReservationId = window.Payment.ReservationId;
                        db.Entry(payment).State = EntityState.Modified;
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
                 
                  Payment? payment = selectedItem as Payment;
                  if (payment == null) return;

                  db.Payments.Remove(payment);
                  db.SaveChanges();

              }));
        }
    }
}
}
