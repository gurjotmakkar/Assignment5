using Assignment5.Models;
using Assignment5.ServiceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment5.Controllers
{
    //For add use case I am keeping all properties (can be null for now) for future purpose
    public class EmployeeAdd
    {
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }

        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        public int? ReportsToEmployeeId { get; set; }
    }

    public class EmployeeBase : EmployeeAdd
    {
        [Key]
        public int EmployeeId { get; set; }
    }

    public class EmployeeEditInfo
    {
        [Key]
        public int EmployeeId { get; set; }
        
        [StringLength(20)]
        public string LastName { get; set; }
        
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }

        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        public string Email { get; set; }
    }

    public class EmployeeBaseWithLinks : EmployeeBase
    {
        public EmployeeBaseWithLinks()
        {
            links = new List<link>();
        }   

        public ICollection<link> links { get; set; }
    }
}