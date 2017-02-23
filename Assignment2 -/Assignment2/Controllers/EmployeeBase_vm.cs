using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //added
using System.Linq;
using System.Web;

namespace Assignment2.Controllers
{
    public class EmployeeBase : EmployeeAdd
    {
        public EmployeeBase()
        {
            //EmpId = 0; ?
        }

        [Key]
        public int EmployeeId { get; set; }

    }
}