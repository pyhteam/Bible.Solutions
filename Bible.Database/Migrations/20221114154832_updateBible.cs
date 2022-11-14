using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bible.Database.Migrations
{
    public partial class updateBible : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Bibles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AudioVerses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 11, 14, 22, 48, 31, 972, DateTimeKind.Local).AddTicks(9803),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 11, 14, 22, 40, 5, 590, DateTimeKind.Local).AddTicks(8096));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Bibles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AudioVerses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 11, 14, 22, 40, 5, 590, DateTimeKind.Local).AddTicks(8096),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 11, 14, 22, 48, 31, 972, DateTimeKind.Local).AddTicks(9803));
        }
    }
}
