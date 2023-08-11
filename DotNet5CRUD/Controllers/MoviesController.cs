using DotNet5CRUD.Models;
using DotNet5CRUD.Repositories.Base;
using DotNet5CRUD.Services.GenreService;
using DotNet5CRUD.Services.MovieService;
using DotNet5CRUD.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5CRUD.Controllers
{
    // Without Repositeries
    #region
    //public class MoviesController : Controller
    //{
    //    private readonly ApplicationDbContext _context;
    //    private readonly IToastNotification _toastNotification;
    //    private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
    //    private long _maxAllowedPosterSize = 1048576;

    //    public MoviesController(ApplicationDbContext context, IToastNotification toastNotification)
    //    {
    //        _context = context;
    //        _toastNotification = toastNotification;
    //    }

    //    public async Task<IActionResult> Index()
    //    {
    //        var movies = await _context.Movies.OrderByDescending(x=>x.Rate).ToListAsync();
    //        return View(movies);
    //    }

    //    public async Task<IActionResult> Create()
    //    {
    //        var viewModel = new MovieFormViewModel
    //        {
    //            Genres = await _context.Genres.OrderBy(m=>m.Name).ToListAsync()
    //        };
    //        return View("MovieForm", viewModel);
    //    }
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create(MovieFormViewModel model)
    //    {
    //        if(!ModelState.IsValid)
    //        {
    //            model.Genres = await _context.Genres.OrderBy(m => m.Name).ToListAsync();
    //            return View("MovieForm", model);
    //        }

    //        var files = Request.Form.Files;

    //        if(!files.Any())
    //        {
    //            model.Genres = await _context.Genres.OrderBy(m => m.Name).ToListAsync();
    //            ModelState.AddModelError("Poster", "Please select movie poster!");
    //            return View("MovieForm", model);
    //        }

    //        var poster = files.FirstOrDefault();

    //        if (!_allowedExtenstions.Contains(Path.GetExtension(poster.FileName).ToLower()))
    //        {
    //            model.Genres = await _context.Genres.OrderBy(m => m.Name).ToListAsync();
    //            ModelState.AddModelError("Poster", "Only .PNG, .JPG images are allowed!");
    //            return View("MovieForm", model);
    //        }

    //        if (poster.Length > _maxAllowedPosterSize)
    //        {
    //            model.Genres = await _context.Genres.OrderBy(m => m.Name).ToListAsync();
    //            ModelState.AddModelError("Poster", "Poster cannot be more than 1 MB!");
    //            return View("MovieForm", model);
    //        }

    //        using var dataStream = new MemoryStream();

    //        await poster.CopyToAsync(dataStream);

    //        var movies = new Movie
    //        {
    //            Title = model.Title,
    //            GenreId = model.GenreId,
    //            Year = model.Year,
    //            Rate = model.Rate,
    //            Storeline = model.Storeline,
    //            Poster = dataStream.ToArray()
    //        };

    //        _context.Movies.Add(movies);
    //        _context.SaveChanges();

    //        _toastNotification.AddSuccessToastMessage("Movie Created Successfully");
    //        return RedirectToAction(nameof(Index));
    //    }

    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null)
    //            return BadRequest();

    //        var movie = await _context.Movies.FindAsync(id);

    //        if (movie == null)
    //            return NotFound();

    //        var viewModel = new MovieFormViewModel
    //        {
    //            Id = movie.Id,
    //            Title = movie.Title,
    //            GenreId = movie.GenreId,
    //            Rate = movie.Rate,
    //            Year = movie.Year,
    //            Storeline = movie.Storeline,
    //            Poster = movie.Poster,
    //            Genres = await _context.Genres.OrderBy(m => m.Name).ToListAsync()
    //        };

    //        return View("MovieForm", viewModel);
    //    }
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(MovieFormViewModel model)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            model.Genres = await _context.Genres.OrderBy(m => m.Name).ToListAsync();
    //            return View("MovieForm", model);
    //        }

    //        var movie = await _context.Movies.FindAsync(model.Id);

    //        if (movie == null)
    //            return NotFound();

    //        var files = Request.Form.Files;

    //        if (files.Any())
    //        {
    //            var poster = files.FirstOrDefault();

    //            using var dataStream = new MemoryStream();

    //            await poster.CopyToAsync(dataStream);

    //            model.Poster = dataStream.ToArray();

    //            if (!_allowedExtenstions.Contains(Path.GetExtension(poster.FileName).ToLower()))
    //            {
    //                model.Genres = await _context.Genres.OrderBy(m => m.Name).ToListAsync();
    //                ModelState.AddModelError("Poster", "Only .PNG, .JPG images are allowed!");
    //                return View("MovieForm", model);
    //            }

    //            if (poster.Length > _maxAllowedPosterSize)
    //            {
    //                model.Genres = await _context.Genres.OrderBy(m => m.Name).ToListAsync();
    //                ModelState.AddModelError("Poster", "Poster cannot be more than 1 MB!");
    //                return View("MovieForm", model);
    //            }

    //            movie.Poster = model.Poster;
    //        }

    //        movie.Title = model.Title;
    //        movie.GenreId = model.GenreId;
    //        movie.Year = model.Year;
    //        movie.Rate = model.Rate;
    //        movie.Storeline = model.Storeline;

    //        _context.SaveChanges();

    //        _toastNotification.AddSuccessToastMessage("Movie Updated Successfully");
    //        return RedirectToAction(nameof(Index));
    //    }

    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        if(id is null) 
    //        {
    //            return BadRequest();
    //        }

    //        var movie = await _context.Movies.Include(m=>m.Genre).SingleOrDefaultAsync(x=>x.Id==id);

    //        if(movie == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(movie);
    //    }
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id is null)
    //        {
    //            return BadRequest();
    //        }

    //        var movie = await _context.Movies.FindAsync(id);

    //        if (movie == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.Movies.Remove(movie);
    //        _context.SaveChanges();

    //        return Ok();
    //    }
    //}
    #endregion

    //With Repositeries
    public class MoviesController : Controller
    {
        private readonly IMoiveService _moiveService;
        private readonly IGenreService _genreService;
        private readonly IToastNotification _toastNotification;
        private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 1048576;

        public MoviesController(IMoiveService moiveService, IGenreService genreService, IToastNotification toastNotification)
        {
            _moiveService = moiveService;
            _genreService = genreService;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _moiveService.GetAllMovies(m => m.Rate);
            var descendingMovies = movies.Reverse().ToList();
            return View(descendingMovies);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = await _genreService.GetAllGenres(m => m.Name)
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieFormViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.Genres = await _genreService.GetAllGenres(m => m.Name);
                return View("MovieForm", model);
            }

            var files = Request.Form.Files;

            if (!files.Any())
            {
                model.Genres = await _genreService.GetAllGenres(m => m.Name);
                ModelState.AddModelError("Poster", "Please select movie poster!");
                return View("MovieForm", model);
            }

            var poster = files.FirstOrDefault();

            if (!_allowedExtenstions.Contains(Path.GetExtension(poster.FileName).ToLower()))
            {
                model.Genres = await _genreService.GetAllGenres(m => m.Name);
                ModelState.AddModelError("Poster", "Only .PNG, .JPG images are allowed!");
                return View("MovieForm", model);
            }

            if (poster.Length > _maxAllowedPosterSize)
            {
                model.Genres = await _genreService.GetAllGenres(m => m.Name);
                ModelState.AddModelError("Poster", "Poster cannot be more than 1 MB!");
                return View("MovieForm", model);
            }

            using var dataStream = new MemoryStream();

            await poster.CopyToAsync(dataStream);

            var movies = new Movie
            {
                Title = model.Title,
                GenreId = model.GenreId,
                Year = model.Year,
                Rate = model.Rate,
                Storeline = model.Storeline,
                Poster = dataStream.ToArray()
            };

            await _moiveService.addMovie(movies);

            _toastNotification.AddSuccessToastMessage("Movie Created Successfully");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var movie = await _moiveService.GetMovieByID(id);

            if (movie == null)
                return NotFound();

            var viewModel = new MovieFormViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                GenreId = movie.GenreId,
                Rate = movie.Rate,
                Year = movie.Year,
                Storeline = movie.Storeline,
                Poster = movie.Poster,
                Genres = await _genreService.GetAllGenres(m => m.Name)
            };

            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = await _genreService.GetAllGenres(m => m.Name);
                return View("MovieForm", model);
            }

            var movie = await _moiveService.GetMovieByID(model.Id);

            if (movie == null)
                return NotFound();

            var files = Request.Form.Files;

            if (files.Any())
            {
                var poster = files.FirstOrDefault();

                using var dataStream = new MemoryStream();

                await poster.CopyToAsync(dataStream);

                model.Poster = dataStream.ToArray();

                if (!_allowedExtenstions.Contains(Path.GetExtension(poster.FileName).ToLower()))
                {
                    model.Genres = await _genreService.GetAllGenres(m => m.Name);
                    ModelState.AddModelError("Poster", "Only .PNG, .JPG images are allowed!");
                    return View("MovieForm", model);
                }

                if (poster.Length > _maxAllowedPosterSize)
                {
                    model.Genres = await _genreService.GetAllGenres(m => m.Name);
                    ModelState.AddModelError("Poster", "Poster cannot be more than 1 MB!");
                    return View("MovieForm", model);
                }

                movie.Poster = model.Poster;
            }

            movie.Title = model.Title;
            movie.GenreId = model.GenreId;
            movie.Year = model.Year;
            movie.Rate = model.Rate;
            movie.Storeline = model.Storeline;

            await _moiveService.updateMovie(movie);
            _toastNotification.AddSuccessToastMessage("Movie Updated Successfully");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var movies = await _moiveService.GetAllMovies(new[] { "Genre" });
            var movie = movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var movie = await _moiveService.GetMovieByID(id);

            if (movie == null)
            {
                return NotFound();
            }
            await _moiveService.deleteMovie(movie.Id);
            return Ok();
        }
    }

}
