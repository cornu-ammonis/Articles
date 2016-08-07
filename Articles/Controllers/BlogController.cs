using Articles.Core;
using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Articles.Controllers
{
    public class BlogController : Controller
    {

        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }


        public ViewResult Posts(int p = 1)
        {
           // var posts = _blogRepository.Posts(p - 1, 10);
           // var total_posts = _blogRepository.TotalPosts();
            var viewModel = new ListViewModel(_blogRepository, p);
            ViewBag.Title = "Latest Posts";
            return View("List", viewModel);
        }

        
        public ViewResult Category(string category, int p = 1)
        {
            var viewModel = new ListViewModel(_blogRepository, category, "Category", p);

            if (viewModel.Category == null)
                throw new HttpException(404, "Category not found");

            ViewBag.Title = String.Format(@"{0} posts on category ""{1}""", viewModel.TotalPosts,
                        viewModel.Category.Name);

            return View("list", viewModel);
        }

        public ViewResult Tag(string tag, int p = 1)
        {
            var viewModel = new ListViewModel(_blogRepository, tag, "Tag", p);
            if (viewModel.Tag == null)
                throw new HttpException(404, "Tag not found");

            ViewBag.Title = String.Format(@"{0} posts tagged ""{1}""", viewModel.TotalPosts, viewModel.Tag.Name);

            return View("List", viewModel);
        }

        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
    }
}