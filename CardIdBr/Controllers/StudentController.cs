using CardIdBr.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardIdBr.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public ActionResult Index()
        {
            var listStudents = new List<Student>();
            listStudents.Add(new Student{FullName = "Lucas Rodrigues", Cpf = "12822300690", Rg = "14983233", BirthDate = DateTime.UtcNow, InstituitionName = "UniBh", Course = "Ciência da Computação", SchoolLevel = "Superior"});
            listStudents.Add(new Student{FullName = "Lucas Rodrigues", Cpf = "12822300690", Rg = "14983233", BirthDate = DateTime.UtcNow, InstituitionName = "UniBh", Course = "Ciência da Computação", SchoolLevel = "Superior"});
            listStudents.Add(new Student{FullName = "Lucas Rodrigues", Cpf = "12822300690", Rg = "14983233", BirthDate = DateTime.UtcNow, InstituitionName = "UniBh", Course = "Ciência da Computação", SchoolLevel = "Superior"});
            listStudents.Add(new Student{FullName = "Lucas Rodrigues", Cpf = "12822300690", Rg = "14983233", BirthDate = DateTime.UtcNow, InstituitionName = "UniBh", Course = "Ciência da Computação", SchoolLevel = "Superior"});
            return View(listStudents);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
