using Microsoft.EntityFrameworkCore.Migrations;

namespace AlzheimerDemencia.Migrations
{
    public partial class InsertValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO AspNetUsers(Id, Name, MiddleName, Surname, BirthDate, Address, PhoneNumber, Email, UserType, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES('1aaaaaaa-bbbb-cccc-dddd-3eeeeeeeeeee', 'Sergiy', 'Ivanovich', 'Petrov', '19800618 10:34:09 AM', 'Ludvig Svobody 53', '+3807364581', 'hey@gmail.com', 'Dad', 1, 1, 0, 0, 0)");
            migrationBuilder.Sql("INSERT INTO AspNetUsers(Id, Name, MiddleName, Surname, BirthDate, Address, PhoneNumber, Email, UserType, Diagnosis, StartDate, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES('2aaaaaaa-bbbb-cccc-dddd-1eeeeeeeeeee', 'Maxim', 'Sergievich', 'Petrov', '19960612 10:34:09 AM', 'Ludvig Svobody 53', '+3807364512', 'max@gmail.com', 'Patient', 'Memory Lost Alzheimer', '20201022 10:34:09 AM', 1, 1, 0, 0, 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AspNetUsers");
        }
    }
}
