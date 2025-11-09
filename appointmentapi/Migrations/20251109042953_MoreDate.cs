using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appointmentapi.Migrations
{
    /// <inheritdoc />
    public partial class MoreDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Persons_CdPerson",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "FlAtivo",
                table: "Users",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "CdPerson",
                table: "Users",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "CdUser",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CdPerson",
                table: "Users",
                newName: "IX_Users_PersonId");

            migrationBuilder.RenameColumn(
                name: "CdPerson",
                table: "Persons",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "PhoneId",
                table: "Persons",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    PhoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Unit_Phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitSchedule_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitSpecialty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitSpecialty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitSpecialty_Specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitSpecialty_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PhoneId",
                table: "Persons",
                column: "PhoneId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_Address_ZipCode",
                table: "Address",
                column: "ZipCode");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PersonId",
                table: "Appointment",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_SpecialtyId",
                table: "Appointment",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_UnitId",
                table: "Appointment",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_AddressId",
                table: "Unit",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unit_PhoneId",
                table: "Unit",
                column: "PhoneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitSchedule_UnitId",
                table: "UnitSchedule",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitSpecialty_SpecialtyId",
                table: "UnitSpecialty",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitSpecialty_UnitId",
                table: "UnitSpecialty",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Phone_PhoneId",
                table: "Persons",
                column: "PhoneId",
                principalTable: "Phone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Phone_PhoneId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "UnitSchedule");

            migrationBuilder.DropTable(
                name: "UnitSpecialty");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PhoneId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PhoneId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Users",
                newName: "CdPerson");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Users",
                newName: "FlAtivo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "CdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                newName: "IX_Users_CdPerson");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Persons",
                newName: "CdPerson");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Persons",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Persons_CdPerson",
                table: "Users",
                column: "CdPerson",
                principalTable: "Persons",
                principalColumn: "CdPerson",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
