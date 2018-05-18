using PhotoSharingApp.Model;
using PhotoSharingApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApp.Controllers
{
    [ValueReporter]
    public class CommentController : System.Web.Mvc.Controller
    {
        private PhotoSharingContext context = new PhotoSharingContext();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Display(int id)
        {
            Debug.WriteLine("Comments houni ");
            List<Comment> comments = context.Comments.ToList();
            var verif = comments.Find(comment => comment.photoID == id);
            if (verif != null)
                return View("Display", verif);
            else
                return HttpNotFound();
        }



        [ChildActionOnly]
        public ActionResult _CommentsList(int number = 0)
        {
            Debug.WriteLine("\n ani comment controller \n");

            List<Comment> comments = new List<Comment>();
            if (number == 0)
            {
                comments = context.Comments.ToList();
            }
            else
            {
                comments = (from c in context.Comments
                          select c).ToList();
            }
            return PartialView("_CommentsList", comments);
        }
    }
}