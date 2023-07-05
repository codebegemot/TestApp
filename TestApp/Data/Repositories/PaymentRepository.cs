using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private PaymentContext _context;

        public PaymentRepository(PaymentContext context)
        {
            _context = context;
        }

        public List<Payment> GetPayments()
        {
            return _context.Payments.Include(p => p.Attributes).ToList();
        }
    }
}
