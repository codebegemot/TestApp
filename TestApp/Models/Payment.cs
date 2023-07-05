using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class Payment
    {
        [Key]
        public int RowId { get; set; }
        public int Ticket { get; set; }
        public decimal Total { get; set; }
        public decimal Value { get; set; }
        public decimal Commission { get; set; }
        public List<PaymentAttribute> Attributes { get; set; }
    }
}
