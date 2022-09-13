using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using wellaTestApp.DbModels;
using wellaTestApp.Models;

namespace wellaTestApp.Controllers
{
    public class RegisterController : Controller
    {

        private readonly AppDbContext _context;

        public RegisterController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var user = _context.StudentDatas.ToList();
            return View(user);
        }


        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent(UserModel user)
        {
            if(ModelState.IsValid)
            {
                await _context.StudentDatas.AddAsync(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult EditStudent(int? id)
        { 
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var student = _context.StudentDatas.FirstOrDefault(x => x.Id == id);
            return View(student); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStudent(UserModel model)
        {
            var student = await _context.StudentDatas.FindAsync(model.Id);
            if (student != null) 
            {
                student.Id = model.Id;  
                student.firstName = model.firstName;
                student.lastName = model.lastName;
                student.course = model.course;
                student.age = model.age;    
                student.emailAddress = model.emailAddress;

                _context.StudentDatas.Update(student);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteStudent(UserModel model)
        {
            var student = await _context.StudentDatas.FindAsync(model.Id);
            if (student != null)
            {
                _context.StudentDatas.Remove(student);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
