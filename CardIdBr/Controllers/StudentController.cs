using CardIdBr.Data;
using CardIdBr.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardIdBr.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            return View(_context.Students.ToList());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var studentFromDb = _context.Students.Find(id);

            if (studentFromDb == null)
                return NotFound();

            return View(studentFromDb);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Students.Add(student);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var studentFromDb = _context.Students.Find(id);

            if (studentFromDb == null)
                return NotFound();

            return View(studentFromDb);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Students.Update(student);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var studentFromDb = _context.Students.Find(id);

            if (studentFromDb == null)
                return NotFound();

            return View(studentFromDb);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Student? studentFromDb = _context.Students.Find(id);
                if (studentFromDb == null)
                    return NotFound();
                
                _context.Students.Remove(studentFromDb);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
