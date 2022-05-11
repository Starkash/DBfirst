﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DBfirst.Model
{
    public partial class Customer
    {
        [Key]
        [StringLength(15)]
        public string CustomerId { get; set; }
        [StringLength(75)]
        public string FirstName { get; set; }
        [StringLength(75)]
        public string LastName { get; set; }
        [StringLength(500)]
        public string PhotoUrl { get; set; }
    }
}
