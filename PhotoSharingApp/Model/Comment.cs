using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Model
{
    public class Comment
    {
        public int commentID { get; set;}
        public String user { get; set;}
        public String subject { get; set;}
        public String body { get; set;}
        public int photoID{ get; set;}
        public virtual Photo Photo { get; set;}

    }
}