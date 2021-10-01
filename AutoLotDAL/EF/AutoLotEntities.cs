using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using AutoLotDAL.Interception;
using AutoLotDAL.Models;

namespace AutoLotDAL.EF
{
    public partial class AutoLotEntities : DbContext
    {
        static readonly DatabaseLogger databaseLogger = new DatabaseLogger("sqllog.txt", true);
        public AutoLotEntities() : base("name=AutoLotConnection")
        {
            //DbInterception.Add(new ConsoleWriterInterceptor());
            databaseLogger.StartLogging();
            DbInterception.Add(databaseLogger);
            var context = (this as IObjectContextAdapter).ObjectContext;
            context.ObjectMaterialized += OnObjectMaterialized;
            context.SavingChanges += OnSavingChanges;
        }

        private void OnSavingChanges(object sender, EventArgs eventArgs)
        {
        }

        private void OnObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
        }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Car)
                .WillCascadeOnDelete(false);
        }

        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(databaseLogger);
            databaseLogger.StopLogging();
            base.Dispose(disposing);
        }
    }
}
