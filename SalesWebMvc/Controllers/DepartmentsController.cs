using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {

            List<Department> lista;
            lista = new List<Department>();
            Department Electr = new Department(1, "Electronics");
            Department Fashion = new Department(2, "Fashion");
            lista.Add(Electr);
            lista.Add(Fashion);

            return View(lista);
        }
    }
}