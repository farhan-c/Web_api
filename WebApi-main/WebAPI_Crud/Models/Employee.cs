using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Crud.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } 
        public int EmployeeAge { get; set; }
        public string EmployeeDesignation { get; set; }
        public string EmployeeGender { get; set; }
        public int EmployeeSalary { get; set; }
    }
}