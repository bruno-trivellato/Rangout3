using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rang_Out.Models
{
    public class Seller
    {
        public string Id { get; set; }
        public int Rating { get; set; }
        public double LastPosX { get; set; }
        public double LastPosY { get; set; }
        public DateTime LastTimeConnected { get; set; }
        public string FriendlyLocation { get; set; }
        public double Account { get; set; }
        public string Name { get; set; }

    }
}
