using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAPILib.Models
{
    public class Card
    {
        public required string number { get; set; }
        public required int cvv { get; set; }
        public required string cardholder { get; set; }
        public required string expiration { get; set; }
    }
}
