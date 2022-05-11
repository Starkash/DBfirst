using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DBfirst.Model
{
    [Table("PRODUCTS")]
    public partial class Product
    {
        [Key]
        [StringLength(6)]
        public string Code { get; set; }
        [StringLength(75)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        [StringLength(20)]
        public string Cotegory { get; set; }
        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        [StringLength(555)]
        public string ImageUrl { get; set; }

        [ForeignKey(nameof(Cotegory))]
        [InverseProperty("Products")]
        public virtual Cotegory CotegoryNavigation { get; set; }
    }
}
