using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment5.Models;
using System.Web.Http;
using System.Net;

namespace Assignment5.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper components
        MapperConfiguration config;
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add your own code here

            // Configure AutoMapper...
            config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Employee, EmployeeBase>();

                // Invoice mapping
                cfg.CreateMap<Models.Invoice, Controllers.InvoiceBase>();
                
                //Employee mapping
                cfg.CreateMap<Models.Employee, Controllers.EmployeeBase>()
                .ForMember(dest => dest.ReportsToEmployeeId, opt => opt.MapFrom(src => src.ReportsTo));
                cfg.CreateMap<Controllers.EmployeeAdd, Models.Employee>();
            });

            mapper = config.CreateMapper();

            // Data-handling configuration

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        public IEnumerable<InvoiceBase> InvoiceGetAll()
        {
            // fetching the collection
            var c = ds.Invoices;

            return mapper.Map<IEnumerable<InvoiceBase>>(c);
        }

        public InvoiceBase InvoiceGetById(int id)
        {
            // fetching the object
            var o = ds.Invoices
                    .SingleOrDefault(i => i.InvoiceId == id);

            return (o == null) ? null : mapper.Map<InvoiceBase>(o);
        }

        public IEnumerable<EmployeeBase> EmployeeGetAll()
        {
            // fetching the collection
            var c = ds.Employees
                    .OrderBy(i => i.LastName);

            return mapper.Map<IEnumerable<EmployeeBase>>(c);
        }

        public EmployeeBase EmployeeGetById(int id)
        {
            // fetching the object
            var o = ds.Employees
                    .SingleOrDefault(e => e.EmployeeId == id);

            return (o == null) ? null : mapper.Map<EmployeeBase>(o);
        }

        public EmployeeBase EmployeeAdd(EmployeeAdd newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            else
            {
                Employee addedItem;
                addedItem = mapper.Map<Employee>(newItem);
                ds.Employees.Add(addedItem);
                ds.SaveChanges();

                return mapper.Map<EmployeeBase>(addedItem);
            }
        }

        // Edit employee - contact info only
        public EmployeeBase EmployeeEditInfo(EmployeeEditInfo editedItem)
        {
            // Ensure that we can continue
            if (editedItem == null) { return null; }

            // Attempt to fetch the object
            var storedItem = ds.Employees.Find(editedItem.EmployeeId);

            if (storedItem == null)
            {
                return null;
            }
            else
            {
                // Fetch the object from the data store - ds.Entry(storedItem)
                // Get its current values collection - .CurrentValues
                // Set those to the edited values - .SetValues(editedItem)
                ds.Entry(storedItem).CurrentValues.SetValues(editedItem);
                // The SetValues() method ignores missing properties and navigation properties
                ds.SaveChanges();

                return mapper.Map<EmployeeBase>(storedItem);
            }
        }
    }
}