using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.DbModels;

public partial class DefaultDbContext : DbContext
{
    public DefaultDbContext()
    {
    }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bouquet> Bouquets { get; set; }

    public virtual DbSet<BouquetFlower> BouquetFlowers { get; set; }

    public virtual DbSet<Cashier> Cashiers { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Flower> Flowers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-IQ17U7T4;Initial Catalog=FlowerMarketNikita;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bouquet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Bouquets");

            entity.ToTable("Bouquet");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<BouquetFlower>(entity =>
        {
            entity.ToTable("BouquetFlower");

            entity.Property(e => e.BouquetId).HasColumnName("Bouquet_id");
            entity.Property(e => e.FlowerId).HasColumnName("Flower_id");

            entity.HasOne(d => d.Bouquet).WithMany(p => p.BouquetFlowers)
                .HasForeignKey(d => d.BouquetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BouquetFlower_Bouquet");

            entity.HasOne(d => d.Flower).WithMany(p => p.BouquetFlowers)
                .HasForeignKey(d => d.FlowerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BouquetFlower_Flower");
        });

        modelBuilder.Entity<Cashier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Cashiers");

            entity.ToTable("Cashier");

            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("Date_of_birth");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("Middle_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("Phone_number");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Clients");

            entity.ToTable("Client");

            entity.Property(e => e.ClientAddress)
                .HasMaxLength(50)
                .HasColumnName("Client_address");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("Date_of_birth");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("Middle_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("Phone_number");
        });

        modelBuilder.Entity<Flower>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Flowers");

            entity.ToTable("Flower");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Login, "Unique_Users_Login").IsUnique();

            entity.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
