using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bible.Database.Migrations
{
    public partial class updateDatabase_AddBibles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Sections_SectionId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Books_BookId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Books_BookId",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Verses_Chapters_ChapterId",
                table: "Verses");

            migrationBuilder.DropIndex(
                name: "IX_Languages_BookId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Languages",
                newName: "BiblesId");

            migrationBuilder.AlterColumn<int>(
                name: "ChapterId",
                table: "Verses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Chapters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BiblesId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AudioVerses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 11, 14, 22, 40, 5, 590, DateTimeKind.Local).AddTicks(8096),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 11, 13, 20, 40, 19, 369, DateTimeKind.Local).AddTicks(1936));

            migrationBuilder.CreateTable(
                name: "Bibles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bibles_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BiblesId",
                table: "Books",
                column: "BiblesId");

            migrationBuilder.CreateIndex(
                name: "IX_Bibles_LanguageId",
                table: "Bibles",
                column: "LanguageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Bibles_BiblesId",
                table: "Books",
                column: "BiblesId",
                principalTable: "Bibles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Sections_SectionId",
                table: "Books",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Books_BookId",
                table: "Chapters",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Verses_Chapters_ChapterId",
                table: "Verses",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Bibles_BiblesId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Sections_SectionId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Books_BookId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Verses_Chapters_ChapterId",
                table: "Verses");

            migrationBuilder.DropTable(
                name: "Bibles");

            migrationBuilder.DropIndex(
                name: "IX_Books_BiblesId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BiblesId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "BiblesId",
                table: "Languages",
                newName: "BookId");

            migrationBuilder.AlterColumn<int>(
                name: "ChapterId",
                table: "Verses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Chapters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AudioVerses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 11, 13, 20, 40, 19, 369, DateTimeKind.Local).AddTicks(1936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 11, 14, 22, 40, 5, 590, DateTimeKind.Local).AddTicks(8096));

            migrationBuilder.CreateIndex(
                name: "IX_Languages_BookId",
                table: "Languages",
                column: "BookId",
                unique: true,
                filter: "[BookId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Sections_SectionId",
                table: "Books",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Books_BookId",
                table: "Chapters",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Books_BookId",
                table: "Languages",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Verses_Chapters_ChapterId",
                table: "Verses",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id");
        }
    }
}
