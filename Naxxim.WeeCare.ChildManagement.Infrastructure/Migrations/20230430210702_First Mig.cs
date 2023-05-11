using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Naxxim.WeeCare.ChildManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChildJournals",
                columns: table => new
                {
                    JournalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DepartureTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Napstart = table.Column<TimeSpan>(name: "Nap_start", type: "time", nullable: false),
                    Napend = table.Column<TimeSpan>(name: "Nap_end", type: "time", nullable: false),
                    HealthCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medication = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildJournals", x => x.JournalId);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    ChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    allergy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chronicillness = table.Column<string>(name: "chronic_illness", type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.ChildId);
                });

            migrationBuilder.CreateTable(
                name: "ChildIncidentDetails",
                columns: table => new
                {
                    HealthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfIncident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationOfTheIncident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionsPrises = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InformationAboutMedications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdChild = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildIncidentDetails", x => x.HealthId);
                    table.ForeignKey(
                        name: "FK_ChildIncidentDetails_Children_IdChild",
                        column: x => x.IdChild,
                        principalTable: "Children",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildIncidentDetails_IdChild",
                table: "ChildIncidentDetails",
                column: "IdChild");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildIncidentDetails");

            migrationBuilder.DropTable(
                name: "ChildJournals");

            migrationBuilder.DropTable(
                name: "Children");
        }
    }
}
