using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAPILib.Models
{
    public class Wishlist
    {
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public Wishlist(string[] wishlist, int page, string viewing, int totalItems)
        {
            this.wishlist = wishlist;
            this.page = page;
            this.viewing = viewing;
            this.totalItems = totalItems;
        }

        required public string[] wishlist {  get; set; }
        required public int page { get; set; }
        required public string viewing { get; set; }
        required public int totalItems { get; set; }


    }
}
