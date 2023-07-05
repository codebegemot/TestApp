using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class PaymentAttribute
    {
        public int PaymentId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public Payment Payment { get; set; }
    }
}
