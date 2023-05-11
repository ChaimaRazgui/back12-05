using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Naxxim.WeeCare.ChildManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class journalmodificationmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HealthCondition",
                table: "ChildJournals");

            migrationBuilder.RenameColumn(
                name: "Nap_start",
                table: "ChildJournals",
                newName: "NapStart");

            migrationBuilder.RenameColumn(
                name: "Nap_end",
                table: "ChildJournals",
                newName: "NapEnd");

            migrationBuilder.AddColumn<int>(
                name: "IdChild",
                table: "ChildJournals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "repasMatin",
                table: "ChildJournals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "repasMidi",
                table: "ChildJournals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ChildJournals_IdChild",
                table: "ChildJournals",
                column: "IdChild");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildJournals_Children_IdChild",
                table: "ChildJournals",
                column: "IdChild",
                principalTable: "Children",
                principalColumn: "ChildId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildJournals_Children_IdChild",
                table: "ChildJournals");

            migrationBuilder.DropIndex(
                name: "IX_ChildJournals_IdChild",
                table: "ChildJournals");

            migrationBuilder.DropColumn(
                name: "IdChild",
                table: "ChildJournals");

            migrationBuilder.DropColumn(
                name: "repasMatin",
                table: "ChildJournals");

            migrationBuilder.DropColumn(
                name: "repasMidi",
                table: "ChildJournals");

            migrationBuilder.RenameColumn(
                name: "NapStart",
                table: "ChildJournals",
                newName: "Nap_start");

            migrationBuilder.RenameColumn(
                name: "NapEnd",
                table: "ChildJournals",
                newName: "Nap_end");

            migrationBuilder.AddColumn<string>(
                name: "HealthCondition",
                table: "ChildJournals",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
