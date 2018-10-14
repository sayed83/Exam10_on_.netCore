using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contact10.Models
{
    public class UserDetails
    {
        [Key]
        [StringLength(50)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [StringLength(50)]
        [MinLength(7)]
        public string Password { get; set; }
    }
}
