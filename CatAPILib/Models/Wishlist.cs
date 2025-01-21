using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAPILib.Models
{
    public class Wishlist
    {
        required public Cat[] wishlist {  get; set; }
        required public int page { get; set; }
        required public string viewing { get; set; }
        required public int totalItems { get; set; }

    }
}
