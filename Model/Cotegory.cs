using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DBfirst.Model
{
    public partial class Cotegory
    {
        public Cotegory()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [StringLength(20)]
        public string CtCode { get; set; }
        [StringLength(50)]
        public string CatName { get; set; }

        [InverseProperty(nameof(Product.CotegoryNavigation))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
