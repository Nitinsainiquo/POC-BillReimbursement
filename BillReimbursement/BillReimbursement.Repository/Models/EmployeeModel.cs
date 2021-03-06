using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillReimbursement.Repository.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Key]
        [Required]
        public string? EmailId { get; set; }
        
        [Required]
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
