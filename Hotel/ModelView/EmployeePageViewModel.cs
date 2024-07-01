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
    internal class EmployeePageViewModel:BaseClass
    {
        HotelContext db = new HotelContext();
        private ObservableCollection<Employee> employeetList;
        public ObservableCollection<Employee> EmployeeList
        {
            get { return employeetList; }
            set
            {
                employeetList = value;
                OnPropertyChanged(nameof(EmployeeList));
            }
        }

        public EmployeePage window;

        private Employee? selectedEmployee;
        public Employee? SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }

        public EmployeePageViewModel(EmployeePage w)
        {
            this.window = w;
            db.Database.EnsureCreated();
            db.Employees.Load();
            EmployeeList = db.Employees.Local.ToObservableCollection();
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        AddEditEmployee window = new AddEditEmployee(new Employee());
                        if (window.ShowDialog() == true)
                        {
                            Employee employee = window.Employee;
                            db.Employees.Add(employee);
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
                        Employee? employee = obj as Employee;
                        if (employee == null) return;
                        AddEditEmployee window = new AddEditEmployee(employee!);
                        if (window.ShowDialog() == true)
                        {
                            employee.FirstName = window.Employee.FirstName;
                            employee.LastName = window.Employee.LastName;
                            employee.Position = window.Employee.Position;
                            employee.HireDate = window.Employee.HireDate;
                            employee.Salary = window.Employee.Salary;
                            db.Entry(employee).State = EntityState.Modified;
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
                   
                      Employee? employee = selectedItem as Employee;
                      if (employee == null) return;

                      db.Employees.Remove(employee);
                      db.SaveChanges();

                  }));
            }
        }
    }
}
