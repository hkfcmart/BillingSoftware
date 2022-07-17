using EntityFrameWork.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameWork
{
    public class BillingContext : DbContext
    {
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<BillInventry> BillInventry { get; set; }
        public DbSet<MontlyTable> MontlyTable { get; set; }
        public DbSet<DailyTable> DailyTable { get; set; }
        public DbSet<BillData> BillData { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<ReturnBillData> ReturnBillData { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
                dbContextOptionsBuilder.UseSqlServer(@"Data Source=DESKTOP-Desk1\SQLEXPRESS;Initial Catalog=BillingSoftware;User ID=AbdulKareem;Password=Bismillah_786");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().HasKey(vf => new { vf.MobileNo, vf.BillNo });
            //modelBuilder.Entity<BillInventry>().HasKey(bi => new { bi.Id, bi.BarCode, bi.ManufacturingDate, bi.PurchasedDate });
        }
    }
}
