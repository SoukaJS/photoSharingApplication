using PhotoSharingApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Models
{
    public class PhotoSharingInitializer : DropCreateDatabaseAlways<PhotoSharingContext>
    {
        protected override void Seed(PhotoSharingContext context)
        {


            Debug.WriteLine("eeeeeeeee");
            List<Comment> comments = new List<Comment>();
            List<Photo> photos = new List<Photo>();

            Photo photo = new Photo();
            photo.title = "Title1";
            photo.description = "Description1";
            photo.owner = "Bershka";
            photo.photoFile = System.IO.File.ReadAllBytes("\\Users\\Skandar Ayedi\\Pictures\\1.jpeg");
            photo.createdDate = DateTime.Now;
            photo.imageMimeType = "image/jpeg";
            photos.Add(photo);
            foreach (Photo p in photos)
                context.Photos.Add(p);
            context.SaveChanges();


            Comment comment = new Comment();
            comment.photoID = 1;
            comment.user = "NaokiSato";
            comment.subject = "Test Comment";
            comment.body = "This comment should be appear in photo";
            comments.Add(comment);
            foreach (Comment c in comments)
                context.Comments.Add(c);
            context.SaveChanges();

           // base.Seed(context);
        }
        // define getFileBytes
        /* byte[] getFileBytes(string image)
         {
             return System.IO.File.ReadAllBytes(image);
         }*/

    }
}