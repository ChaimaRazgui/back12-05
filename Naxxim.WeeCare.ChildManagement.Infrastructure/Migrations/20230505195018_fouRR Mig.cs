using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Naxxim.WeeCare.ChildManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fouRRMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentEmail",
                table: "ChildIncidentDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentEmail",
                table: "ChildIncidentDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
