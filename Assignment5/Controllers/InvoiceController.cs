using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment5.Controllers
{
    public class InvoiceController : ApiController
    {
        // Reference to the data manager
        private Manager m = new Manager();

        // GET: api/Invoice
        public IHttpActionResult Get()
        {
            return Ok(m.InvoiceGetAll());
        }

        // GET: api/Invoice/5
        public IHttpActionResult Get(int? id)
        {
            // Attempt to fetch the object
            var o = m.InvoiceGetById(id.GetValueOrDefault());

            // Continue?
            if (o == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(o);
            }
        }
    }
}
