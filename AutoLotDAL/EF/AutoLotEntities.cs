using System.Data.Entity;
using AutoLotDAL.Models;

namespace AutoLotDAL.EF
{
    public partial class AutoLotEntities : DbContext
    {
        public AutoLotEntities()
            : base("name=AutoLotConnection")
        {
        }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<inventory> inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Custld);

            modelBuilder.Entity<inventory>()
                .Property(e => e.Make)
                .IsFixedLength();

            modelBuilder.Entity<inventory>()
                .Property(e => e.Color)
                .IsFixedLength();

            modelBuilder.Entity<inventory>()
                .Property(e => e.PetName)
                .IsFixedLength();

            modelBuilder.Entity<inventory>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Inventory)
                .HasForeignKey(e => e.Carld)
                .WillCascadeOnDelete(false);
        }
    }
}
