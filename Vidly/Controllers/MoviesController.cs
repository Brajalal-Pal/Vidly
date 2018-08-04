using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie(){Id = 2, Name = "Terminator 2"},
                new Movie(){Id = 1, Name = "Shrek"},
                new Movie(){Id = 3, Name = "Titanic"}
            };
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer(){Name = "John Smith", Id = 2},
                new Customer(){Name = "Marry Williams", Id = 3},
                new Customer(){Name = "Brajalal Pal", Id = 1}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            
            return View(viewModel);

            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});            

        }

        public ActionResult Edit(int id)
        {
            return Content("id =" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {

            //if (!pageIndex.HasValue)
            //    pageIndex = 1;
            //if (sortBy.IsNullOrWhiteSpace())
            //    sortBy = "Name";
            //return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
            return View(GetMovies());
        }

        //Attribute Routing
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);

        }

        public ActionResult Details(int id)
        {
            var movies = GetMovies();
            var movie = movies.Find(c => c.Id == id);

            return View(movie);
        }
    }
}