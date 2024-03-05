using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSupermarket.MODEL
{
    public class Employee
    {
        [Key]
        public int EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
        public string OfficeCode { get; set; }
        [ForeignKey("OfficeCode")]
        public Office Office { get; set; }

        public int? ReportsTo { get; set; }
        [ForeignKey("ReportsTo")]
        public Employee Manager { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
