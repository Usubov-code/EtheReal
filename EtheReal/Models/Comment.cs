using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EtheReal.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
       
      
        [MaxLength(150), MinLength(3)]
        public string Testimonials { get; set; }

        [ForeignKey("CustomUser")]
        public string CustomUserId { get; set; }
        public CustomUser CustomUser { get; set; }

    }
}
