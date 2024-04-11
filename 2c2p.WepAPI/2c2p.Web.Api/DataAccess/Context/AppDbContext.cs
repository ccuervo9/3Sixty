
using DataAccess.Model.Inquiry;

using DataAccess.Model.Payment;
using DataAccess.Model.Refund;
using DataAccess.Model.Settlement;
using DataAccess.Model.TabOrder;
using DataAccess.Model.Void;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;



namespace DataAccess.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionListModel>().HasNoKey();
            modelBuilder.Entity<PaymentModel>().HasNoKey();
            modelBuilder.Entity<PrePaymentUIModel>().HasNoKey();
            modelBuilder.Entity<TransactionStatusModel>().HasNoKey();
            modelBuilder.Entity<RefundModel>().HasNoKey();
            modelBuilder.Entity<SettlementModel>().HasNoKey();
            modelBuilder.Entity<VoidModel>().HasNoKey();
            modelBuilder.Entity<TabOrderModel>().HasNoKey();

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<PaymentModel> Payment { get; set; }
        public DbSet<PrePaymentUIModel> PrepaymentUi { get; set; }
        public DbSet<TransactionListModel> TransactionList { get; set; }
        public DbSet<TransactionStatusModel> TransactionStatus { get; set; }
        public DbSet<RefundModel> Refund { get; set; }
        public DbSet<SettlementModel> Settlement { get; set; }
        public DbSet<VoidModel> Void { get; set; }
        public DbSet<TabOrderModel> TabOrder { get; set; }      


    }


}
