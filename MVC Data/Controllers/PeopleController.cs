using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Data.Models;

namespace MVC_Data.Controllers
{
    public class PeopleController : Controller
    {

        IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }
        
        // GET
        [HttpGet]
        public IActionResult Index(string searchString)
        {
            PersonView pv = new PersonView();

            if (!String.IsNullOrEmpty(searchString))
            {
                pv.persons = _personService.FilterPersonCity(searchString);
            }
            else
            {
                pv.persons = _personService.AllPersons();
            }
            return View(pv);

        }

        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Person person = _personService.FindPerson((int)id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            _personService.DeletePerson((int)id);

            return RedirectToAction("Index");

        }

        public IActionResult Create(string name, int phone, string city)
        {
            if (name == null||  city == null)
            {
                return RedirectToAction("Index");
            }

            Person person = _personService.CreatePerson( name,  phone,  city);

            return RedirectToAction("Index");

        }

    }

}

