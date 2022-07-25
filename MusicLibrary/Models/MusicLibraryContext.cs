using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MusicLibrary.Models
{
    public partial class MusicLibraryContext : DbContext
    {
        public MusicLibraryContext()
        {
        }

        public MusicLibraryContext(DbContextOptions<MusicLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<Collection> Collections { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Song> Songs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MusicLibrary;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("Artist");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SongId).HasColumnName("SongID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.Collections)
                    .HasForeignKey(d => d.SongId)
                    .HasConstraintName("FK_Collections_Songs");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Songs_Artist");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Songs_Genre");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CollectionId).HasColumnName("CollectionID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Collection)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CollectionId)
                    .HasConstraintName("FK_User_Collections");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
