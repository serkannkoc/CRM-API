using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Company2.Models
{
    public partial class Company2Context : DbContext
    {
        public Company2Context()
        {
        }

        public Company2Context(DbContextOptions<Company2Context> options)
            : base(options)
        {

        }


        public virtual DbSet<PreRegistration> PreRegistrations { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<ProductUserPermission> ProductUserPermissions { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInformation> UserInformations { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Company2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<PreRegistration>().HasQueryFilter(b => b.DeletedAt == null);
            modelBuilder.Entity<UserInformation>().HasQueryFilter(b => b.DeletedAt == null);

            modelBuilder.Entity<PreRegistration>(entity =>
            {
                entity.ToTable("PreRegistration");

                entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.DeletedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.Email).HasMaxLength(320);

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Ip).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.DeletedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_ProductCategories");

                entity.HasOne(d => d.Detail)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DetailId)
                    .HasConstraintName("FK_Products_ProductDetails");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.DeletedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.DeletedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<ProductUserPermission>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.DeletedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductUserPermissions)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductUserPermissions_Products");

                entity.HasOne(d => d.UserPermission)
                    .WithMany(p => p.ProductUserPermissions)
                    .HasForeignKey(d => d.UserPermissionId)
                    .HasConstraintName("FK_ProductUserPermissions_UserPermissions");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.DeletedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Sales_Products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Sales_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.DeletedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.Email).HasMaxLength(320);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");

                entity.HasOne(d => d.UserPermission)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserPermissionId)
                    .HasConstraintName("FK_User_UserPermissions");
            });

            modelBuilder.Entity<UserInformation>(entity =>
            {
                entity.ToTable("UserInformation");

                entity.Property(e => e.City).HasMaxLength(35);

                entity.Property(e => e.Country).HasMaxLength(35);

                entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.DeletedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.FullAddress).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInformations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserInformation_User");
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.DeletedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.Property(e => e.UpdatedAt).HasColumnType("smalldatetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }


}
