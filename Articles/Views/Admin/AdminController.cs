using Articles.Core;
using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Articles.Views.Admin
{
    public class AdminController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        //constructer for ninject dependency injection 
        public AdminController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }

        public JsonResult Posts(JqInViewModel jqParams)
        {
            var posts = _blogRepository.Posts(jqParams.page - 1, jqParams.rows, jqParams.sidx, jqParams.sord == "asc");
            var totalPosts = _blogRepository.TotalPosts(false);

            return Json(new
            {
                page = jqParams.page,
                records = totalPosts,
                rows = posts,
                total = Math.Ceiling(Convert.ToDouble(totalPosts) / jqParams.rows)
            }, JsonRequestBehavior.AllowGet);
        }
    }
}