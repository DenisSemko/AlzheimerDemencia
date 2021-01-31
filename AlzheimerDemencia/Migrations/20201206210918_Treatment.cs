using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlzheimerDemencia.Migrations
{
    public partial class Treatment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DoctorUserIdId = table.Column<Guid>(nullable: true),
                    PatientUserIdId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateBegin = table.Column<DateTime>(nullable: true),
                    DateEnd = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatment_AspNetUsers_DoctorUserIdId",
                        column: x => x.DoctorUserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treatment_AspNetUsers_PatientUserIdId",
                        column: x => x.PatientUserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_DoctorUserIdId",
                table: "Treatment",
                column: "DoctorUserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_PatientUserIdId",
                table: "Treatment",
                column: "PatientUserIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Treatment");
        }
    }
}
