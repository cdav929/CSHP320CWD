using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InventoryItemsDB
{
    public partial class HomeInventoryContext : DbContext
    {
        public HomeInventoryContext()
        {
        }

        public HomeInventoryContext(DbContextOptions<HomeInventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<InventoryItems> InventoryItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=HomeInventory;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItems>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemAddedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ItemBrand).HasMaxLength(50);

                entity.Property(e => e.ItemDatePurchased).HasColumnType("datetime");

                entity.Property(e => e.ItemModelNumber).HasMaxLength(50);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ItemNotes).HasMaxLength(1);

                entity.Property(e => e.ItemPrice).HasColumnType("money");

                entity.Property(e => e.ItemPurchaseLocation).HasMaxLength(1000);

                entity.Property(e => e.ItemSerialNumber).HasMaxLength(50);
            });
        }
    }
}
