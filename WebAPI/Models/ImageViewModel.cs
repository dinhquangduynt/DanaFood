using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ImageViewModel
    {
        [Required]
        public HttpPostedFileBase FileAttachment { get; set; }
    }
}