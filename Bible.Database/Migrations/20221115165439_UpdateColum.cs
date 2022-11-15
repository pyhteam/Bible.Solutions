using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bible.Database.Migrations
{
    public partial class UpdateColum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PartParentId",
                table: "Part",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AudioVerses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 11, 15, 23, 54, 39, 478, DateTimeKind.Local).AddTicks(6645),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 11, 15, 23, 38, 6, 345, DateTimeKind.Local).AddTicks(3524));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PartParentId",
                table: "Part",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AudioVerses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 11, 15, 23, 38, 6, 345, DateTimeKind.Local).AddTicks(3524),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 11, 15, 23, 54, 39, 478, DateTimeKind.Local).AddTicks(6645));
        }
    }
}
