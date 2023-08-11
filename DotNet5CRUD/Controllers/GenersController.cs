using DotNet5CRUD.Models;
using DotNet5CRUD.Services.GenreService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5CRUD.Controllers
{
    
    #region
    //public class GenersController : Controller
    //{
    //    private readonly ApplicationDbContext _context;

    //    public GenersController(ApplicationDbContext context)
    //    {
    //        _context = context; 
    //    }

    //    public async Task<IActionResult> Index()
    //    {
    //        var Genres = await _context.Genres.OrderBy(x => x.Name).ToListAsync();
    //        return View(Genres);
    //    }
    //    public async Task<IActionResult> ShowMovies(int?id)
    //    {
    //        var Genre = await _context.Genres.Include(m=>m.Movies).SingleOrDefaultAsync(m=>m.Id==id);

    //        return PartialView("_ShowMovies", Genre.Movies);
    //    }
    //}
    #endregion
    public class GenersController : Controller
    {
        private readonly IGenreService _genreService;

        public GenersController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {
            var Genres = await _genreService.GetAllGenres(m => m.Name);
            return View(Genres);
        }
        public async Task<IActionResult> ShowMovies(int? id)
        {
            var Genres = await _genreService.GetAllGenres(new[] { "Movies" });
            var Genre = Genres.SingleOrDefault(x => x.Id == id);
            //var Genre = await _context.Genres.Include(m => m.Movies).SingleOrDefaultAsync(m => m.Id == id);

            return PartialView("_ShowMovies", Genre.Movies);
        }
    }
}
