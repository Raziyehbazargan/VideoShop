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

        public String Name { get; set; }

        [Display(Name= "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        [Display(Name = "In Stock")]
        [Range(1,100)]
        public int InStock { get; set; }

        public GenreType GenreType { get; set; }

        [Display(Name = "Genre Type")]
        public byte GenreTypeId { get; set; }


    }
}