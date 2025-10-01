using System.Threading.Tasks;
using System.Web.Mvc;
using DAL.Models;
using DAL;

namespace ExcelEducation.Controllers
{
    public class CoursesController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var courses = await OnlineCourseDB.LoadAllCoursesAsync();
            return View(courses);
        }

        public async Task<ActionResult> Details(int id)
        {
            var course = await OnlineCourseDB.LoadCourseById(id);
            if (course == null)
                return HttpNotFound();

            return View(course);
        }
    }
}
