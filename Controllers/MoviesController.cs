using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.ViewModels;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Random()
        {
            var movie = new List<Movie>
            {
                new Movie() { Name = "Shrek!" },
                new Movie() {Name = "Wall-e"}
            };


            var viewModel = new RandomMovieViewModel
            {
                Movie = movie
            };

            return View(viewModel);


        }

        public IActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        }

        [Route("movies/ByReleaseDate/{year}/{month}")]
        public IActionResult ByReleaseDate(int year, int month)
        {

            return Content(year + "/" + month);
        }
    }
}
