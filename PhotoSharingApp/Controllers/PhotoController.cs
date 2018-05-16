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
    public class PhotoController : Controller
    {
        private PhotoSharingContext context = new PhotoSharingContext();
        // GET: Photo
        public ActionResult Index()
        {

            Debug.WriteLine("aaaaaaaaa1111111");

            var photo = new Photo();
            return View(context.Photos.First<Photo>());
            //context.Photos.First<Photo>());
        }
    }
}