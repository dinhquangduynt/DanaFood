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

        //[Required]
        //[MaxLength(50)]
        //public string Name { set; get; }

        //[MaxLength(50)]
        //public string Department { set; get; }

        //[MaxLength(50)]
        //public string Mobile { set; get; }

        //[MaxLength(50)]
        //public string Email { set; get; }

        //public bool Status { set; get; }

        //public int? DisplayOrder { set; get; }
    }
}