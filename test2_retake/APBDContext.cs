using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using test2_retake.Models;

namespace test2_retake
{
    public partial class APBDContext : DbContext
    {
        public APBDContext()
        {
        }

        public APBDContext(DbContextOptions<APBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Actions { get; set; } = null!;
        public virtual DbSet<FireTruck> FireTrucks { get; set; } = null!;
        public virtual DbSet<FireTruckAction> FireTruckActions { get; set; } = null!;
        public virtual DbSet<Firefighter> Firefighters { get; set; } = null!;
        public virtual DbSet<Firefighter_Action> FirefighterActions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=APBD;user id=sa;password=Password.1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>(entity =>
            {
                entity.HasKey(e => e.IdAction)
                    .HasName("Action_pk");

                entity.ToTable("Action");

                entity.Property(e => e.IdAction).ValueGeneratedNever();

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasData(
                    new Action
                    {
                        IdAction = 1,
                        StartTime = Convert.ToDateTime("12/12/2002"),
                        EndTime = Convert.ToDateTime("12/15/2002"),
                        NeedSpecialEquipment = true
                    },
                    new Action
                    {
                        IdAction = 2,
                        StartTime = Convert.ToDateTime("01/12/1990"),
                        EndTime = Convert.ToDateTime("02/15/1990"),
                        NeedSpecialEquipment = false
                    }
                    );
            });

            modelBuilder.Entity<FireTruck>(entity =>
            {
                entity.HasKey(e => e.IdFireTruck)
                    .HasName("FireTruck_pk");

                entity.ToTable("FireTruck");

                entity.Property(e => e.IdFireTruck).ValueGeneratedNever();

                entity.Property(e => e.OperationalNumber).HasMaxLength(10);

                entity.HasData(
                    new FireTruck
                    {
                        IdFireTruck = 1,
                        OperationalNumber = "NVW",
                        SpecialEquipment = false
                    }
                );
            });

            modelBuilder.Entity<FireTruckAction>(entity =>
            {
                entity.HasKey(e => e.IdFireTruckAction)
                    .HasName("FireTruck_Action_pk");

                entity.ToTable("FireTruck_Action");

                entity.Property(e => e.IdFireTruckAction).ValueGeneratedNever();

                entity.Property(e => e.ActionIdAction).HasColumnName("Action_IdAction");

                entity.Property(e => e.AssignmentDate).HasColumnType("datetime");

                entity.Property(e => e.FireTruckIdFireTruck).HasColumnName("FireTruck_IdFireTruck");

                entity.HasOne(d => d.ActionIdActionNavigation)
                    .WithMany(p => p.FireTruckActions)
                    .HasForeignKey(d => d.ActionIdAction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FireTruck_Action_Action");

                entity.HasOne(d => d.FireTruckIdFireTruckNavigation)
                    .WithMany(p => p.FireTruckActions)
                    .HasForeignKey(d => d.FireTruckIdFireTruck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FireTruck_Action_FireTruck");

                entity.HasData(
                    new FireTruckAction
                    {
                        IdFireTruckAction = 1,
                        FireTruckIdFireTruck = 1,
                        ActionIdAction = 1,
                        AssignmentDate = Convert.ToDateTime("12/12/2002")
                    }
                );
            });
            modelBuilder.Entity<Firefighter_Action>(entity =>
            {

            });
            modelBuilder.Entity<Firefighter>(entity =>
            {
                entity.HasKey(e => e.IdFirefighter)
                    .HasName("Firefighter_pk");

                entity.ToTable("Firefighter");

                entity.Property(e => e.IdFirefighter).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.HasMany(d => d.IdActions)
                    .WithMany(p => p.IdFirefighters)
                    .UsingEntity<Dictionary<string, object>>(
                        "FirefighterAction",
                        l => l.HasOne<Action>().WithMany().HasForeignKey("IdAction").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Firefighter_Action_Action"),
                        r => r.HasOne<Firefighter>().WithMany().HasForeignKey("IdFirefighter").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Firefighter_Action_Firefighter"),
                        j =>
                        {
                            j.HasKey("IdFirefighter", "IdAction").HasName("Firefighter_Action_pk");

                            j.ToTable("Firefighter_Action");
                        });

                entity.HasData(
                    new Firefighter
                    {
                        IdFirefighter = 1,
                        FirstName = "John",
                        LastName = "Lenovo"
                    },
                    new Firefighter
                    {
                        IdFirefighter = 2,
                        FirstName = "Dave",
                        LastName = "Coby"
                    },
                    new Firefighter
                    {
                        IdFirefighter = 3,
                        FirstName = "Kurt",
                        LastName = "Cobain"
                    }
                );
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
