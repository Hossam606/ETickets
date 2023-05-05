using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using eTickets.Models;

namespace eTickets.Data;

public partial class DbEticketsContext : DbContext
{
    public DbEticketsContext()
    {
    }

    public DbEticketsContext(DbContextOptions<DbEticketsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Cinema> Cinemas { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= DESKTOP-SIIB9G2\\SQLEXPRESS;Database=Db_ETickets;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasMany(d => d.Producers).WithMany(p => p.Actors)
                .UsingEntity<Dictionary<string, object>>(
                    "ActorsMovie",
                    r => r.HasOne<Producer>().WithMany()
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Ators_Movies_Producers"),
                    l => l.HasOne<Actor>().WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Ators_Movies_Actors"),
                    j =>
                    {
                        j.HasKey("ActorId", "ProducerId").HasName("PK_Ators_Movies");
                        j.ToTable("Actors_Movies");
                        j.IndexerProperty<int>("ProducerId").HasColumnName("producerId");
                    });
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasOne(d => d.Cinema).WithMany(p => p.Movies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movies_Cinemas");

            entity.HasOne(d => d.Producer).WithMany(p => p.Movies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movies_Producers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
