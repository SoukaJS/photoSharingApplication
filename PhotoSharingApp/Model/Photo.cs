using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Model
{
    public class Photo
    {


        public int photoID { get; set; }
        public String title { get; set; }
        [DisplayName("Picture")]
        public Byte[] photoFile { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode =true)]
        public DateTime createdDate { get; set; }
        public String owner { get; set; }
        [DataType(DataType.MultilineText)]
        public String description { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public string imageMimeType { get; set; }

    }
}