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
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
                dbContextOptionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JR8NP15\SQLEXPRESS;Initial Catalog=BillingDatabase;User ID=AbdulKareem;Password=Bismillah_786");
        }
    }
}
