using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<PaymentContext>
    {
        public PaymentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PaymentContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testDb;Integrated Security=True;");

            return new PaymentContext(optionsBuilder.Options);
        }
    }
}
