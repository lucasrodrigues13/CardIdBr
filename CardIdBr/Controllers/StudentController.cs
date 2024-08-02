using CardIdBr.Data;
using CardIdBr.Entities;
using CardIdBr.Models.Student;
using CardIdBr.Util.Image;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using QRCoder;

namespace CardIdBr.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageManager _imageManager;
        public StudentController(ApplicationDbContext context, IImageManager imageManager)
        {
            _context = context;
            _imageManager = imageManager;
        }
        public ActionResult Index()
        {
            return View(_context.Students.ToList());
        }

        public ActionResult Details(int id)
        {
            var studentFromDb = _context.Students.Find(id);

            if (studentFromDb == null)
                return NotFound();

            return View(studentFromDb);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel studentViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = new Student
                    {
                        BirthDate = DateTime.Now,
                        Course = studentViewModel.Course,
                        Cpf = studentViewModel.Cpf,
                        Email = studentViewModel.Email,
                        FullName = studentViewModel.FullName,
                        Id = studentViewModel.Id,
                        InstituitionName = studentViewModel.InstituitionName,
                        Rg = studentViewModel.Rg,
                        SchoolLevel = studentViewModel.SchoolLevel,
                        UseCode = studentViewModel.UseCode,
                    };
                    student.ImagePath = _imageManager.SaveUserImage(studentViewModel);

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

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var studentViewModel = _context.Students.Where(a => a.Id == id).Select(b => new StudentViewModel
            {
                Id = b.Id,
                UseCode = b.UseCode,
                SchoolLevel = b.SchoolLevel,
                Rg = b.Rg,
                BirthDate = b.BirthDate,
                Course = b.Course,
                Email = b.Email,
                FullName = b.FullName,
                Cpf = b.Cpf,
                InstituitionName = b.InstituitionName
            }).FirstOrDefault();

            if (studentViewModel == null)
                return NotFound();

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(studentViewModel.Cpf, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                studentViewModel.QrCode = Convert.ToBase64String(qrCode.GetGraphic(50, false));
            }

            return View(studentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var studentFromDb = _context.Students.Find(studentViewModel.Id);

                    if (studentFromDb == null)
                        return NotFound();

                    studentFromDb.BirthDate = studentViewModel.BirthDate;
                    studentFromDb.Course = studentViewModel.Course;
                    studentFromDb.Cpf = studentViewModel.Cpf;
                    studentFromDb.Email = studentViewModel.Email;
                    studentFromDb.FullName = studentViewModel.FullName;
                    studentFromDb.Id = studentViewModel.Id;
                    studentFromDb.InstituitionName = studentViewModel.InstituitionName;
                    studentFromDb.Rg = studentViewModel.Rg;
                    studentFromDb.SchoolLevel = studentViewModel.SchoolLevel;
                    studentFromDb.ImagePath = _imageManager.SaveUserImage(studentViewModel);

                    _context.Students.Update(studentFromDb);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

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
