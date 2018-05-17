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
            List<Photo> photo = new List<Photo>();

            Photo ph = new Photo();
            ph.title = "Test Photo";
            ph.description = "tesst tesst :p";
            ph.owner = "NaokiSato";
            ph.photoFile = System.IO.File.ReadAllBytes("\\Users\\Skandar Ayedi\\Pictures\\hsouna.jpeg");
            ph.createdDate = DateTime.Now;
            ph.imageMimeType = "image/jpeg";
            photo.Add(ph);
            foreach (Photo p in photo)
                context.Photos.Add(p);
            context.SaveChanges();
            Comment comm = new Comment();
            comm.photoID = 1;
            comm.user = "NaokiSato";
            comm.subject = "Test Comment";
            comm.body = "This comment should be appear in photo";
            comments.Add(comm);
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