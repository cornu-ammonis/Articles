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

        //constructer for ninject dependency injection 
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

        public ViewResult Search(string s, int p = 1)
        {
            var viewModel = new ListViewModel(_blogRepository, s, "Search", p);

            ViewBag.Title = String.Format(@"{0} posts found for search ""{1}""", viewModel.TotalPosts, s);
            return View("List", viewModel);
        }


        public ViewResult Post(int year, int month, string title)
        {
            var post = _blogRepository.Post(year, month, title);

            if (post == null)
                throw new HttpException(404, "post not found");

            if (post.Published == false && User.Identity.IsAuthenticated == false)
                throw new HttpException(401, "The post is not published");

            return View(post);
        }

        [ChildActionOnly]
        public PartialViewResult Sidebars()
        {
            var widgetViewModel = new WidgetViewModel(_blogRepository);

            return PartialView("_Sidebars", widgetViewModel);
        }

        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
    }
}