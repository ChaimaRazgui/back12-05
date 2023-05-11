using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Naxxim.WeeCare.ChildManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class secondMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InformationAboutMedications",
                table: "ChildIncidentDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InformationAboutMedications",
                table: "ChildIncidentDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
