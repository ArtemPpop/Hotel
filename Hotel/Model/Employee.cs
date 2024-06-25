﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Model;

public partial class Employee:BaseClass
{
    [Key]
    private string? employeeId;
    public string? EmployeeId
    {
        get { return employeeId; }
        set
        {
            employeeId = value;
            OnPropertyChanged(nameof(EmployeeId));
        }
    }

    private string? firstName;
    public string? FirstName
    {
        get { return firstName; }
        set
        {
            firstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }

    private string? lastName;
    public string? LastName
    {
        get { return lastName; }
        set
        {
            lastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }

    private string? position;
    public string? Position
    {
        get { return position; }
        set
        {
            position = value;
            OnPropertyChanged(nameof(Position));
        }
    }

    private string? hireDate;
    public string? HireDate
    {
        get { return hireDate; }
        set
        {
            hireDate = value;
            OnPropertyChanged(nameof(HireDate));
        }
    }

    private string? salary;
    public string? Salary
    {
        get { return salary; }
        set
        {
            salary = value;
            OnPropertyChanged(nameof(Salary));
        }
    }
}
