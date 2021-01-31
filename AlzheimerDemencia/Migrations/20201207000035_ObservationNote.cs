using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlzheimerDemencia.Migrations
{
    public partial class ObservationNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObservationNote",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DoctorUserIdId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TreatmentIdId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObservationNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObservationNote_AspNetUsers_DoctorUserIdId",
                        column: x => x.DoctorUserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ObservationNote_Treatment_TreatmentIdId",
                        column: x => x.TreatmentIdId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObservationNote_DoctorUserIdId",
                table: "ObservationNote",
                column: "DoctorUserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ObservationNote_TreatmentIdId",
                table: "ObservationNote",
                column: "TreatmentIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObservationNote");
        }
    }
}
