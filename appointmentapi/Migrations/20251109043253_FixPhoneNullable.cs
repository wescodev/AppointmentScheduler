using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appointmentapi.Migrations
{
    /// <inheritdoc />
    public partial class FixPhoneNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_PhoneId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneId",
                table: "Persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PhoneId",
                table: "Persons",
                column: "PhoneId",
                unique: true,
                filter: "[PhoneId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_PhoneId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PhoneId",
                table: "Persons",
                column: "PhoneId",
                unique: true);
        }
    }
}
