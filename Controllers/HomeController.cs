using Microsoft.AspNetCore.Mvc;
using Tran_Thanh_991515427_Exam.Models;

namespace Tran_Thanh_991515427_Exam.Controllers
{
    public class HomeController : Controller
    {
        //pass data to the view
        private ITeacherRepository repository;
        public HomeController(ITeacherRepository teacherRepository)
        {
            repository = teacherRepository;
        }
        public IActionResult Index() => View(repository.Teachers);
    }
}

