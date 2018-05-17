using PhotoSharingApp.Model;
using PhotoSharingApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PhotoSharingApp.Controllers;

namespace PhotoSharingApp.Controller
{
    [ValueReporter]
    public class PhotoController : System.Web.Mvc.Controller
    {
        private PhotoSharingContext context = new PhotoSharingContext();
        // GET: Photo
        public ActionResult Index()
        {
            //var photo = new Photo(); 
            return View("Index");
            //context.Photos.First<Photo>()
            //context.Photos.ToList()
        }

        public ActionResult Display(int id)
        {
            List<Photo> photos = context.Photos.ToList();
            var verif = photos.Find(photo => photo.photoID == id);
            if (verif != null)
                return View("Display", verif);
            else
                return HttpNotFound();
        }
        public ActionResult Create()
        {
            Photo photo = new Photo();
            photo.createdDate = DateTime.Now;
            return View("Create", photo);
        }
        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase image)
        {
            photo.createdDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    photo.imageMimeType = image.ContentType;
                    photo.photoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo.photoFile, 0, image.ContentLength);
                    context.Photos.Add(photo);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", photo);
            }
        }

        public ActionResult Delete(int id)
        {
            List<Photo> photos = context.Photos.ToList();
            var verif = photos.Find(photo => photo.photoID == id);
            if (verif == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("Delete", verif);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Photo> photos = context.Photos.ToList();
            var verif = photos.Find(photo => photo.photoID == id);
            context.Entry(verif).State = EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public FileContentResult GetImage(int id)
        {
            List<Photo> photos = context.Photos.ToList();
            var verif = photos.Find(photo => photo.photoID == id);
            if (verif != null)
            {

                return (new FileContentResult(verif.photoFile, verif.imageMimeType));
            }
            else
            {
                return null;
            }
        }
        [ChildActionOnly]
        public ActionResult _PhotoGallery(int number = 0)
        {
            Debug.WriteLine("\n ani houniiiii \n");

            List<Photo> photos = new List<Photo>();
            if (number == 0)
            {
                photos = context.Photos.ToList();
            }
            else
            {
                photos = (from p in context.Photos
                          orderby p.createdDate descending
                          select p).Take(number).ToList();
            }
            return PartialView("_PhotoGallery", photos);
        }
    }

}