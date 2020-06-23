using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecureData.Models
{
    public class Order
    {
        [Key]
        public int number { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public string company { get; set; } 
        public double amount { get; set; }
        public bool paid { get; set; }
    }

}
