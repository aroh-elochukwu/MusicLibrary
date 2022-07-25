﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicLibrary.Models;

#nullable disable

namespace MusicLibrary.Migrations
{
    [DbContext(typeof(MusicLibraryContext))]
    [Migration("20220724234013_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MusicLibrary.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Artist", (string)null);
                });

            modelBuilder.Entity("MusicLibrary.Models.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("SongId")
                        .HasColumnType("int")
                        .HasColumnName("SongID");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("SongId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("MusicLibrary.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genre", (string)null);
                });

            modelBuilder.Entity("MusicLibrary.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArtistId")
                        .HasColumnType("int")
                        .HasColumnName("ArtistID");

                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("GenreID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("MusicLibrary.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CollectionId")
                        .HasColumnType("int")
                        .HasColumnName("CollectionID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("MusicLibrary.Models.Collection", b =>
                {
                    b.HasOne("MusicLibrary.Models.Song", "Song")
                        .WithMany("Collections")
                        .HasForeignKey("SongId")
                        .HasConstraintName("FK_Collections_Songs");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("MusicLibrary.Models.Song", b =>
                {
                    b.HasOne("MusicLibrary.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .IsRequired()
                        .HasConstraintName("FK_Songs_Artist");

                    b.HasOne("MusicLibrary.Models.Genre", "Genre")
                        .WithMany("Songs")
                        .HasForeignKey("GenreId")
                        .IsRequired()
                        .HasConstraintName("FK_Songs_Genre");

                    b.Navigation("Artist");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MusicLibrary.Models.User", b =>
                {
                    b.HasOne("MusicLibrary.Models.Collection", "Collection")
                        .WithMany("Users")
                        .HasForeignKey("CollectionId")
                        .HasConstraintName("FK_User_Collections");

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("MusicLibrary.Models.Artist", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("MusicLibrary.Models.Collection", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MusicLibrary.Models.Genre", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("MusicLibrary.Models.Song", b =>
                {
                    b.Navigation("Collections");
                });
#pragma warning restore 612, 618
        }
    }
}
