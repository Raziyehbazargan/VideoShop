using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoShop.Models;

namespace VideoShop.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreType> GenreTypes { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Genre Type")]
        [Required]
        public byte GenreTypeId { get; set; }

        [Display(Name = "In Stock")]
        [Range(1, 20)]
        [Required]
        public byte? InStock { get; set; }

        public string Title => Id == 0 ? "New Movie" : "Edit Movie";

        //Default constructor
        public MovieFormViewModel()
        {
            Id = 0;
        }
        //constructor
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            InStock = movie.InStock;
            GenreTypeId = movie.GenreTypeId;
        }
    }
}