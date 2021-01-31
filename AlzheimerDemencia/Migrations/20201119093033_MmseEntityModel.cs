using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlzheimerDemencia.Migrations
{
    public partial class MmseEntityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MmseSurveyId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MmseSurvey",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    DataSubmit = table.Column<DateTime>(nullable: false),
                    YearQuestion = table.Column<string>(nullable: false),
                    SeasonQuestion = table.Column<string>(nullable: false),
                    DayQuestion = table.Column<string>(nullable: false),
                    MonthQuestion = table.Column<string>(nullable: false),
                    DateQuestion = table.Column<DateTime>(nullable: false),
                    CountryQuestion = table.Column<string>(nullable: false),
                    RegionQuestion = table.Column<string>(nullable: false),
                    CityQuestion = table.Column<string>(nullable: false),
                    HomeAddressQuestion = table.Column<string>(nullable: false),
                    NumberBuildingQuestion = table.Column<int>(nullable: false),
                    FirstObject = table.Column<string>(nullable: false),
                    SecondObject = table.Column<string>(nullable: false),
                    ThirdObject = table.Column<string>(nullable: false),
                    FirstCount = table.Column<int>(nullable: false),
                    SecondCount = table.Column<int>(nullable: false),
                    ThirdCount = table.Column<int>(nullable: false),
                    FourthCount = table.Column<int>(nullable: false),
                    FifthCount = table.Column<int>(nullable: false),
                    FirstShownObject = table.Column<string>(nullable: false),
                    SecondShownObject = table.Column<string>(nullable: false),
                    RepeatPhrase = table.Column<string>(nullable: false),
                    FirstTask = table.Column<bool>(nullable: false),
                    SecondTask = table.Column<bool>(nullable: false),
                    ThirdTask = table.Column<bool>(nullable: false),
                    FourthTask = table.Column<bool>(nullable: false),
                    WriteSentence = table.Column<string>(nullable: false),
                    DrawPicture = table.Column<bool>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MmseSurvey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MmseSurvey_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MmseSurvey_UserId",
                table: "MmseSurvey",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MmseSurvey");

            migrationBuilder.DropColumn(
                name: "MmseSurveyId",
                table: "AspNetUsers");
        }
    }
}
