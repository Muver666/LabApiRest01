using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Employe name is a required failed. ")]
        [MaxLength(30, ErrorMessage = "Maximun length for the name is 30 characters")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Age is a required failed. ")]
        public int Age { get; set; }
        [Required(ErrorMessage ="Position is a required failed. ")]
        [MaxLength(20, ErrorMessage = "Maximun length for the position is 20 characters")]
        public string? Position { get; set; }
        [ForeignKey(nameof(Company))]
        public Guid CompaniId { get; set; }
        public Company? company { get; set; }

    }
}
