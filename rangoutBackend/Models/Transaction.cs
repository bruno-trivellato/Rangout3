using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rangoutBackend.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public DateTime BeginDate { get; set; }
        public int AmountOfFood { get; set; }
        public string FoodId { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

    }
}
