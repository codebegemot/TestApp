using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Data
{
    public class PaymentContext : DbContext
    {
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentAttribute> PaymentAttributes { get; set; }

        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .HasKey(p => p.RowId);

            modelBuilder.Entity<PaymentAttribute>()
                .HasKey(pa => new { pa.PaymentId, pa.Name });


            modelBuilder.Entity<PaymentAttribute>()
                .HasOne(pa => pa.Payment)
                .WithMany(p => p.Attributes)
                .HasForeignKey(pa => pa.PaymentId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
