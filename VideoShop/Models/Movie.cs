using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoShop.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Display(Name= "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        [Display(Name = "In Stock")]
        [Range(1,20)]
        public byte InStock { get; set; }

        public GenreType GenreType { get; set; }

        [Display(Name = "Genre Type")]
        public byte GenreTypeId { get; set; }
    }
}