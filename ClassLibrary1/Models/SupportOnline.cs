using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThucPham.Model.Models
{
    [Table("SupportOnlines")]
    public class SupportOnline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [MaxLength(50)]
        public string Email { set; get; }

 
        [MaxLength(200)]
        public string Title { set; get; }

        [MaxLength(500)]
        public string Content { set; get; }


        [MaxLength(100)]
        public string Name { set; get; }
    }
}