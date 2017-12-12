using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VideoShop.Models;

namespace VideoShop.Controllers.Api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies/

    }
}