using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Contact10.Models
{
    public class ContactDBContext:DbContext
    {
       
        public ContactDBContext(DbContextOptions<ContactDBContext> options):base(options)
        {

        }
        public virtual DbSet<Contact> Contact { get; set; }
    }

    public class student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
