﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contact10.Models
{
    public class CVM
    {
        public int id { get; set; }
        [Required]
        public string email { get; set; }
    }
}
