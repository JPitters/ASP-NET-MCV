using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment2.Models;

namespace Assignment2.Controllers
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
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Employee, EmployeeBase>();
                
                //Creating map from Models.Employee dm class to Controller.EmployeeBase vm class 
                cfg.CreateMap<Models.Employee, Controllers.EmployeeBase>();
                //Creating map from Controller.EmployeeAdd vm class to Models.Employee dm class 
                cfg.CreateMap<Controllers.EmployeeAdd, Models.Employee>();
            });

            mapper = config.CreateMapper();
            
            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()

        public IEnumerable<EmployeeBase> EmployeeGetAll()
        {
            return mapper.Map<IEnumerable<EmployeeBase>>(ds.Employees);
            //return (Map<IEnumerable<EmployeeBase>>)ds.Employees;
        }

        public EmployeeBase EmployeeGetOne(int id)
        {
            //Attempt to get the object from data store, and store it in eo (Employee Object) variable
            var eo = ds.Employees.Find(id);

            //return the object (or null, if eo results to a null value) 
            return (eo == null) ? null : mapper.Map<EmployeeBase>(eo);
        }

        public EmployeeBase EmployeeAddNew(EmployeeAdd newItem)
        {
            //Create a new Item using the model template and attempt to add it to data store with mapping
            var addedItem = ds.Employees.Add(mapper.Map<Employee>(newItem));
            ds.SaveChanges(); //Save the changes made

            //Check if the item was added by its value, and return the object or a null value
            return (addedItem == null) ? null : mapper.Map<EmployeeBase>(addedItem);
        }




    }
}