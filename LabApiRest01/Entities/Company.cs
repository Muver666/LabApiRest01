using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Entities.Models
{
    public class Company
    {

        [Column("CompayId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Employe name is a required failed. ")]
        [MaxLength(60, ErrorMessage = "Maximun length for the name is 60 characters")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Compani address is a required failed. ")]
        [MaxLength(60, ErrorMessage = "Maximun length for the address is 60 characters")]
        public string? Address { get; set; }
        public string? Country { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
