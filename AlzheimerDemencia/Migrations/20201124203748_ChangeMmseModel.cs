using Microsoft.EntityFrameworkCore.Migrations;

namespace AlzheimerDemencia.Migrations
{
    public partial class ChangeMmseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsFirstObject",
                table: "MmseSurvey",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsSecondObject",
                table: "MmseSurvey",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsThirdObject",
                table: "MmseSurvey",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFirstObject",
                table: "MmseSurvey");

            migrationBuilder.DropColumn(
                name: "IsSecondObject",
                table: "MmseSurvey");

            migrationBuilder.DropColumn(
                name: "IsThirdObject",
                table: "MmseSurvey");
        }
    }
}
