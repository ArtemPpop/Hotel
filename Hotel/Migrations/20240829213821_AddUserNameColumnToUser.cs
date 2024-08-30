using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNameColumnToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(name: "EmployeeID ", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(name: "FirstName ", type: "TEXT", nullable: true),
                    LastName = table.Column<string>(name: "LastName ", type: "TEXT", nullable: true),
                    Position = table.Column<string>(type: "TEXT", nullable: true),
                    HireDate = table.Column<string>(name: "HireDate ", type: "TEXT", nullable: true),
                    Salary = table.Column<int>(name: "Salary ", type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Guests ",
                columns: table => new
                {
                    GuestID = table.Column<int>(name: "GuestID ", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(name: "FirstName ", type: "TEXT", nullable: true),
                    LastName = table.Column<string>(name: "LastName ", type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(name: "PhoneNumber ", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests ", x => x.GuestID);
                });

            migrationBuilder.CreateTable(
                name: "GuestServices ",
                columns: table => new
                {
                    GuestServiceID = table.Column<int>(name: "GuestServiceID ", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReservationID = table.Column<int>(name: "ReservationID ", type: "INTEGER", nullable: true),
                    ServiceID = table.Column<int>(name: "ServiceID ", type: "INTEGER", nullable: true),
                    ServiceDate = table.Column<string>(name: "ServiceDate ", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestServices ", x => x.GuestServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Payments ",
                columns: table => new
                {
                    PaymentID = table.Column<int>(name: "PaymentID ", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReservationID = table.Column<int>(name: "ReservationID ", type: "INTEGER", nullable: false),
                    PaymentDate = table.Column<string>(name: "PaymentDate ", type: "TEXT", nullable: true),
                    AmountPaid = table.Column<double>(name: "AmountPaid ", type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments ", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "Reservations ",
                columns: table => new
                {
                    ReservationID = table.Column<int>(name: "ReservationID ", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuestID = table.Column<int>(name: "GuestID ", type: "INTEGER", nullable: false),
                    RoomID = table.Column<int>(name: "RoomID ", type: "INTEGER", nullable: false),
                    CheckInDate = table.Column<DateTime>(name: "CheckInDate ", type: "TEXT", nullable: true),
                    CheckOutDate = table.Column<DateTime>(name: "CheckOutDate ", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations ", x => x.ReservationID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms ",
                columns: table => new
                {
                    RoomID = table.Column<int>(name: "RoomID ", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomNumber = table.Column<int>(name: "RoomNumber ", type: "INTEGER", nullable: false),
                    RoomType = table.Column<string>(name: "RoomType ", type: "TEXT", nullable: true),
                    Capacity = table.Column<int>(name: "Capacity ", type: "INTEGER", nullable: false),
                    PricePerNight = table.Column<int>(name: "PricePerNight ", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms ", x => x.RoomID);
                });

            migrationBuilder.CreateTable(
                name: "Services ",
                columns: table => new
                {
                    ServiceID = table.Column<int>(name: "ServiceID ", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceName = table.Column<string>(name: "ServiceName ", type: "TEXT", nullable: true),
                    ServicePrice = table.Column<string>(name: "ServicePrice ", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services ", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(name: "UserId ", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(name: "UserName ", type: "TEXT", nullable: true),
                    Password = table.Column<string>(name: "Password ", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Guests ");

            migrationBuilder.DropTable(
                name: "GuestServices ");

            migrationBuilder.DropTable(
                name: "Payments ");

            migrationBuilder.DropTable(
                name: "Reservations ");

            migrationBuilder.DropTable(
                name: "Rooms ");

            migrationBuilder.DropTable(
                name: "Services ");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
