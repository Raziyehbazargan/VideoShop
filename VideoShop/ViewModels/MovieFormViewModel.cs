using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoShop.Models;

namespace VideoShop.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreType> GenreTypes { get; set; }
        public Movie Movie { get; set; }
    }
}