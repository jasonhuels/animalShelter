using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace AnimalShelter.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly AnimalShelterContext _db;

        public AnimalsController(AnimalShelterContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Animal> model = _db.Animals.Include(animals => animals.Species).ToList();
            return View(model);

        }
        // public Task<IActionResult> Index(string sortOrder)
        // {
        //     ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //     ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
        //     var students = from s in _context.Students
        //                 select s;
        //     switch (sortOrder)
        //     {
        //         case "name_desc":
        //             students = students.OrderByDescending(s => s.LastName);
        //             break;
        //         case "Date":
        //             students = students.OrderBy(s => s.EnrollmentDate);
        //             break;
        //         case "date_desc":
        //             students = students.OrderByDescending(s => s.EnrollmentDate);
        //             break;
        //         default:
        //             students = students.OrderBy(s => s.LastName);
        //             break;
        //     }
        //     return View(students.AsNoTracking().ToListAsync());
        // }

        // public ActionResult Create()
        // {
        //     return View();
        // }

        public ActionResult Create()
        {
            ViewBag.SpeciesID = new SelectList(_db.Species, "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            _db.Animals.Add(animal);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            Animal thisAnimal= _db.Animals.FirstOrDefault(animals => animals.ID == id);
            return View(thisAnimal);
        }
        public ActionResult Edit(int id)
        {
            var thisAnimal = _db.Animals.FirstOrDefault(animals => animals.ID == id);
            ViewBag.SpeciesID = new SelectList(_db.Species, "ID", "Name");
            return View(thisAnimal);
        }

        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            _db.Entry(animal).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisAnimal = _db.Animals.FirstOrDefault(animals => animals.ID == id);
            return View(thisAnimal);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisAnimal = _db.Animals.FirstOrDefault(animals => animals.ID == id);
            _db.Animals.Remove(thisAnimal);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}