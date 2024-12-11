using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeManagement.MVC.Migrations
{
    /// <inheritdoc />
    public partial class lastmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExperianceYear",
                table: "Masters",
                newName: "ExperienceYear");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "ExperienceYear",
                table: "Masters",
                newName: "ExperianceYear");
        }
    }
}
