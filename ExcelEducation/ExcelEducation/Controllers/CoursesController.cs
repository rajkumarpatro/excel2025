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
        public async Task<ActionResult> GetCoursesText()
        {
            // Fetch all courses
            var courses = await DAL.OnlineCourseDB.LoadAllCoursesAsync();

            if (courses == null || !courses.Any())
                return Content("No courses found.", "text/plain");

            var sb = new StringBuilder();

            foreach (var course in courses)
            {
                // Construct a relative URL for the course page
                string courseUrl = $"/Courses/Details/{course.COURSE_ID}";

                sb.AppendLine(
                    $"CourseId: {course.COURSE_ID}, " + 
                    $"Name: {course.M_COURSE_NAME ?? "N/A"}, " +
                    $"Course: {course.COURSE ?? "N/A"}, " +
                    $"Lectures: {course.TOTAL_NO_LECT ?? 0}, " +
                    $"Duration: {course.VIDEO_HR.ToString() ?? "N/A"}, " +
                    $"Mode: {course.PRODUCT_TYPE ?? "N/A"}, " +
                    $"Price: ₹{course.PRICE.ToString("0.##") ?? "0"}, " +
                    $"URL: {courseUrl}"
                );
                sb.AppendLine(
                     
                );
            }

            return Content(sb.ToString(), "text/plain");
        }




    }
}
