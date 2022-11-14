using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bible.Database.Migrations
{
    public partial class updateRelationShip_Bible_Language : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bibles_LanguageId",
                table: "Bibles");

            migrationBuilder.DropColumn(
                name: "BiblesId",
                table: "Languages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AudioVerses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 11, 14, 22, 58, 35, 729, DateTimeKind.Local).AddTicks(405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 11, 14, 22, 48, 31, 972, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.CreateIndex(
                name: "IX_Bibles_LanguageId",
                table: "Bibles",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bibles_LanguageId",
                table: "Bibles");

            migrationBuilder.AddColumn<int>(
                name: "BiblesId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AudioVerses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 11, 14, 22, 48, 31, 972, DateTimeKind.Local).AddTicks(9803),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 11, 14, 22, 58, 35, 729, DateTimeKind.Local).AddTicks(405));

            migrationBuilder.CreateIndex(
                name: "IX_Bibles_LanguageId",
                table: "Bibles",
                column: "LanguageId",
                unique: true);
        }
    }
}
