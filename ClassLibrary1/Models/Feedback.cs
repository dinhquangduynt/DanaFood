using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucPham.Model.Models
{
    [Table("Feedbacks")]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { set; get; }

            [StringLength(250)]
            [Required]
            public string Name { set; get; }

            [StringLength(250)]
            public string Email { set; get; }

            [StringLength(500)]
            public string Message { set; get; }

            public DateTime CreatedDate { set; get; }

            [MaxLength(200)]
            public string Title { set; get; }

            [MaxLength(500)]
            public string EmailContent { set; get; }

            public bool? Status { set; get; }
    }
}

