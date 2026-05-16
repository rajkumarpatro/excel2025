using DAL;
using DAL.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic; 

namespace ExcelEducation.Controllers
{
    public class BlogDetailsController : Controller
    {
        private readonly object blogRepository;

        //public async Task<ActionResult> Index() 
        //{ 
        //    var blogid = Request.QueryString["blogid"];
        //    var recentblogs = await ExcelInfoDB.GetBlogsAsync();
        //    var blogdetails = await ExcelInfoDB.GetBlogDetailsAsync(Convert.ToInt32(blogid));

        //    var blogDetailsViewModel = new BlogDetails
        //    {
        //        Blog = blogdetails,
        //        RecentBlogs = recentblogs
        //    };
        //    return View("index",blogDetailsViewModel);
        //}

        public async Task<ActionResult> Index()
        {
            var blogid = Request.QueryString["blogid"];

            var recentblogs = await ExcelInfoDB.GetBlogsAsync();

            var blogdetails = await ExcelInfoDB
                .GetBlogDetailsAsync(Convert.ToInt32(blogid));

            var blogDetailsViewModel = new BlogDetails
            {
                Blog = blogdetails,
                RecentBlogs = recentblogs
            };

            return View("Index", blogDetailsViewModel);
        }


        public async Task<ActionResult> AllBlogs()
        {
            var blogs = await ExcelInfoDB.GetBlogsAsync();

            var sortedBlogs = blogs?
                .OrderByDescending(b => b.BlogDate)
                .ToList();

            BlogModel model = new BlogModel
            {
                Blogs = sortedBlogs
            };

            return View(model);
        }


    }
}