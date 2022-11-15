﻿// <auto-generated />
using System;
using Bible.Database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bible.Database.Migrations
{
    [DbContext(typeof(BibleContext))]
    partial class BibleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Bible.Database.Entities.AudioVerse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 11, 15, 23, 38, 6, 345, DateTimeKind.Local).AddTicks(3524));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)")
                        .HasDefaultValue("admin");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LinkAudio")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("VerseId")
                        .HasColumnType("int");

                    b.Property<string>("Vocal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("VerseId");

                    b.ToTable("AudioVerses");
                });

            modelBuilder.Entity("Bible.Database.Entities.Bibles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Bibles");
                });

            modelBuilder.Entity("Bible.Database.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodeBook")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Introduce")
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Bible.Database.Entities.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("Bible.Database.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Bible.Database.Entities.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BiblesId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("PartParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BiblesId");

                    b.HasIndex("PartParentId");

                    b.ToTable("Part");
                });

            modelBuilder.Entity("Bible.Database.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChapterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Bible.Database.Entities.Verse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Number")
                        .HasColumnType("tinyint");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Verses");
                });

            modelBuilder.Entity("Bible.Database.Entities.AudioVerse", b =>
                {
                    b.HasOne("Bible.Database.Entities.Verse", "Verse")
                        .WithMany("AudioVerses")
                        .HasForeignKey("VerseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Verse");
                });

            modelBuilder.Entity("Bible.Database.Entities.Bibles", b =>
                {
                    b.HasOne("Bible.Database.Entities.Language", "Language")
                        .WithMany("Bibles")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Bible.Database.Entities.Book", b =>
                {
                    b.HasOne("Bible.Database.Entities.Part", "Part")
                        .WithMany("Books")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");
                });

            modelBuilder.Entity("Bible.Database.Entities.Chapter", b =>
                {
                    b.HasOne("Bible.Database.Entities.Book", "Book")
                        .WithMany("Chapters")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Bible.Database.Entities.Part", b =>
                {
                    b.HasOne("Bible.Database.Entities.Bibles", "Bibles")
                        .WithMany("Parts")
                        .HasForeignKey("BiblesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bible.Database.Entities.Part", "PartParent")
                        .WithMany("ChildParts")
                        .HasForeignKey("PartParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Bibles");

                    b.Navigation("PartParent");
                });

            modelBuilder.Entity("Bible.Database.Entities.Section", b =>
                {
                    b.HasOne("Bible.Database.Entities.Chapter", "Chapter")
                        .WithMany("Sections")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("Bible.Database.Entities.Verse", b =>
                {
                    b.HasOne("Bible.Database.Entities.Section", "Section")
                        .WithMany("Verses")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("Bible.Database.Entities.Bibles", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("Bible.Database.Entities.Book", b =>
                {
                    b.Navigation("Chapters");
                });

            modelBuilder.Entity("Bible.Database.Entities.Chapter", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("Bible.Database.Entities.Language", b =>
                {
                    b.Navigation("Bibles");
                });

            modelBuilder.Entity("Bible.Database.Entities.Part", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("ChildParts");
                });

            modelBuilder.Entity("Bible.Database.Entities.Section", b =>
                {
                    b.Navigation("Verses");
                });

            modelBuilder.Entity("Bible.Database.Entities.Verse", b =>
                {
                    b.Navigation("AudioVerses");
                });
#pragma warning restore 612, 618
        }
    }
}
