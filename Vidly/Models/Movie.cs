using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Movie")]
        [StringLength(100)]
        public string Name { get; set; }
        public string Genre { get; set; }
    }
}