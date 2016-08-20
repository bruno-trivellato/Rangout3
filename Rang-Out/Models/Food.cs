using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Rang_Out.Models
{
    public class Food
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Image Image { get; set; }
        public double Price { get; set; }

    }
}
