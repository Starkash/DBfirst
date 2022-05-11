using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DBfirst.Model;

#nullable disable

namespace DBfirst.Data
{
    public partial class DbFirstCrudContext : DbContext
    {
        public DbFirstCrudContext()
        {
        }

        public DbFirstCrudContext(DbContextOptions<DbFirstCrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cotegory> Cotegories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(local);initial catalog=DbFirstCrud; trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cotegory>(entity =>
            {
                entity.HasKey(e => e.CtCode)
                    .HasName("PK__Cotegori__01A6D04E4CA5713D");

                entity.Property(e => e.CtCode).IsUnicode(false);

                entity.Property(e => e.CatName).IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.PhotoUrl).IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__PRODUCTS__A25C5AA68563D155");

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.Cotegory).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.CotegoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Cotegory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRODUCTS__Cotego__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
