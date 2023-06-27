using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SetDefaultsForEmployeeVacations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SickVacationRemaining",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 10,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnnualVacationRemaining",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 11,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SickVacationRemaining",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 10);

            migrationBuilder.AlterColumn<int>(
                name: "AnnualVacationRemaining",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 11);
        }
    }
}
