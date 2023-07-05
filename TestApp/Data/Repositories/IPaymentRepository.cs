using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Data.Repositories
{
    public interface IPaymentRepository
    {
        public List<Payment> GetPayments();
    }
}
