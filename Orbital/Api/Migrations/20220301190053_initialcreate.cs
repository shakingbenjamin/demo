using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaseSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ScheduleType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaseSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleEntryDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntryNumber = table.Column<string>(nullable: true),
                    EntryDate = table.Column<string>(nullable: true),
                    EntryType = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<string>(nullable: true),
                    PlanningRef = table.Column<string>(nullable: true),
                    PropertyDescription = table.Column<string>(nullable: true),
                    LeaseTerm = table.Column<string>(nullable: true),
                    LesseeTitle = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    LeaseScheduleDetailDtoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleEntryDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleEntryDto_LeaseSchedules_LeaseScheduleDetailDtoId",
                        column: x => x.LeaseScheduleDetailDtoId,
                        principalTable: "LeaseSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEntryDto_LeaseScheduleDetailDtoId",
                table: "ScheduleEntryDto",
                column: "LeaseScheduleDetailDtoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleEntryDto");

            migrationBuilder.DropTable(
                name: "LeaseSchedules");
        }
    }
}
