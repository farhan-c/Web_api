using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using WebAPI_Crud.Models;

namespace WebAPI_Crud.Controllers
{
    public class CrudMVCController : Controller
    {
        HttpClient client=new HttpClient();
        // GET: CrudMVC
        public ActionResult Index()
        {
            var list = new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44325/api/crudapi");
            var response = client.GetAsync("CrudApi");
            response.Wait();
             var test=response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display=test.Content.ReadAsAsync<List<Employee>>();
                display.Wait();
                list=display.Result;
            }


            return View(list);
        }
        public ActionResult Details(int id)
        {
            Employee e=null;
            client.BaseAddress = new Uri("https://localhost:44325/api/crudapi");
            var response = client.GetAsync("CrudApi?id="+id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {   
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e= display.Result;
            }            
            return View(e);
        }
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            client.BaseAddress = new Uri("https://localhost:44325/api/crudapi");
            var response = client.PostAsJsonAsync<Employee>("CrudApi",employee);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44325/api/crudapi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            client.BaseAddress = new Uri("https://localhost:44325/api/crudapi");
            var response = client.PutAsJsonAsync<Employee>("CrudApi", employee);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44325/api/crudapi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44325/api/crudapi");
            var response = client.DeleteAsync("CrudApi/" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}