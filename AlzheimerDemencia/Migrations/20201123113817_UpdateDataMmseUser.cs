using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlzheimerDemencia.Migrations
{
    public partial class UpdateDataMmseUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MmseSurvey_AspNetUsers_UserId",
                table: "MmseSurvey");

            migrationBuilder.DropIndex(
                name: "IX_MmseSurvey_UserId",
                table: "MmseSurvey");

            migrationBuilder.DropColumn(
                name: "MmseSurveyId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "MmseSurvey",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_MmseSurvey_UserId",
                table: "MmseSurvey",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MmseSurvey_AspNetUsers_UserId",
                table: "MmseSurvey",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MmseSurvey_AspNetUsers_UserId",
                table: "MmseSurvey");

            migrationBuilder.DropIndex(
                name: "IX_MmseSurvey_UserId",
                table: "MmseSurvey");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "MmseSurvey",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MmseSurveyId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MmseSurvey_UserId",
                table: "MmseSurvey",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MmseSurvey_AspNetUsers_UserId",
                table: "MmseSurvey",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
