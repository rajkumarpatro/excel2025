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


        public ActionResult CaFoundationRaipur()
        {
            return View();
        }
        public ActionResult CaFoundationChhattisgarh()
        {
            return View();
        }
        public ActionResult CaIntermediateRaipur()
        {
            return View();
        }
        public ActionResult CsCoachingRaipur()
        {
            return View();
        }
        public ActionResult Results()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
     

    }
