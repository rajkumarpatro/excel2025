using DAL;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExcelEducation.Controllers
{
    public class CoursesController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var courses = await OnlineCourseDB.LoadAllCoursesAsync();
            return View(courses);
        }
    }
}
