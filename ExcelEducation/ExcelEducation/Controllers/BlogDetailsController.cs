using DAL;
using DAL.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExcelEducation.Controllers
{
    public class BlogDetailsController : Controller
    {
        // GET: BlogDetails
        public async Task<ActionResult> Index()
        {
            var blogid = Request.QueryString["blogid"];
            var recentblogs = await ExcelInfoDB.GetBlogsAsync();
            var blogdetails = await ExcelInfoDB.GetBlogDetailsAsync(Convert.ToInt32(blogid));
            var blogDetailsViewModel = new BlogDetails
            {
                Blog = blogdetails,
                RecentBlogs = recentblogs
            };
            return View("index",blogDetailsViewModel);
        }
    }
}