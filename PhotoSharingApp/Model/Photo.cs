using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Model
{
    public class Photo
    {

        public int photoID { get; set; }
        public String title { get; set; }
        public Byte[] photoFile { get; set; }
        public DateTime createdDate { get; set; }
        public String owner { get; set; }
    }
}