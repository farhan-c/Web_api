using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Mvc.Razor;
using System.Web.UI.WebControls;
using WebAPI_Crud.Models;

namespace WebAPI_Crud.Controllers
{
    public class CrudApiController : ApiController
    {
        EmployeeDBContext dB=new EmployeeDBContext();
        [HttpGet]
        public IHttpActionResult GetEmployee()
        {
            var list = dB.Employees.ToList();   
            return Ok(list);

        }
        [HttpGet]
        public IHttpActionResult GetEmployeeByID(int id)
        {
            var data = dB.Employees.Where(x=>x.EmployeeId== id).FirstOrDefault();
            return Ok(data);

        }
        [HttpPost]
        public IHttpActionResult EmployeeInsert(Employee emp)
        {
            dB.Employees.Add(emp);
            dB.SaveChanges();
            return Ok();    
        }
        [HttpPut]
        public IHttpActionResult EmployeeEdit(Employee emp)
        {
            dB.Entry(emp).State = EntityState.Modified;
            dB.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult EmployeeDelete(int id)
        {
            var data=dB.Employees.Where(x=>x.EmployeeId== id).FirstOrDefault(); 
            dB.Employees.Remove(data);
            dB.SaveChanges();
            return Ok();
        }


    }
}
