using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoShop.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Created { get; set; }
        public int InStock { get; set; }
        public GenreType GenreType { get; set; }
        public byte GenreTypeId { get; set; }


    }
}