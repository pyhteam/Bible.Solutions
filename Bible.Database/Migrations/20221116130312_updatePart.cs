using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bible.Database.Migrations
{
    public partial class updatePart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PartParentId",
                table: "Part",
                type: "int",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AudioVerses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 11, 16, 20, 3, 12, 636, DateTimeKind.Local).AddTicks(8027),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 11, 15, 23, 54, 39, 478, DateTimeKind.Local).AddTicks(6645));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PartParentId",
                table: "Part",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "NULL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AudioVerses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 11, 15, 23, 54, 39, 478, DateTimeKind.Local).AddTicks(6645),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 11, 16, 20, 3, 12, 636, DateTimeKind.Local).AddTicks(8027));
        }
    }
}
