using Assignment5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment5.Controllers
{
    public class InvoiceAdd
    {
        public DateTime InvoiceDate { get; set; }

        [StringLength(70)]
        public string BillingAddress { get; set; }

        [StringLength(40)]
        public string BillingCity { get; set; }

        [StringLength(40)]
        public string BillingState { get; set; }

        [StringLength(40)]
        public string BillingCountry { get; set; }

        [StringLength(10)]
        public string BillingPostalCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Total { get; set; }

    }

    public class InvoiceBase : InvoiceAdd
    {
        [Key]
        public int InvoiceId { get; set; }
    }
}