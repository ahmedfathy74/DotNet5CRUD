using DotNet5CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5CRUD.Controllers
{
    public class GenersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenersController(ApplicationDbContext context)
        {
            _context = context; 
        }
        
        public async Task<IActionResult> Index()
        {
            var Genres = await _context.Genres.OrderBy(x => x.Name).ToListAsync();
            return View(Genres);
        }
        public async Task<IActionResult> ShowMovies(int?id)
        {
            var Genre = await _context.Genres.Include(m=>m.Movies).SingleOrDefaultAsync(m=>m.Id==id);
           
            return PartialView("_ShowMovies", Genre.Movies);
        }
    }
}
