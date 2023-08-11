using DotNet5CRUD.Models;
using DotNet5CRUD.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNet5CRUD.Services.GenreService
{
    public class GenreService : IGenreService
    {
        private readonly IGenericRepo<Genre> _GenreService;
        public GenreService(IGenericRepo<Genre> GenreService)
        {
            _GenreService = GenreService;
        }

        public async Task addGenre(Genre Genre)
        {
            try
            {
                if (Genre is null)
                {
                    throw new ArgumentNullException(nameof(Genre));
                }
                else
                {
                    await _GenreService.Add(Genre);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task deleteGenre(int id)
        {
            try
            {
                await _GenreService.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Genre>> GetAllGenres(string[] includes = null)
        {
            try
            {
                return await _GenreService.GetAllEntries(includes);
            }
            catch (Exception)
            {
                throw new Exception("Error , for get all Genres, try again later plz");
            }
        }

        public async Task<IEnumerable<Genre>> GetAllGenres<TKey>(Expression<Func<Genre, TKey>> orderBy = null, string[] includes = null)
        {
            try
            {
                return await _GenreService.GetAllEntries(orderBy, includes);
            }
            catch (Exception)
            {
                throw new Exception("Error , for get all Genres, try again later plz");
            }
        }

        public async Task<Genre> GetGenreByID(int? GenreId)
        {
            return await _GenreService.GetByID(GenreId);
        }

        public async Task<Genre> updateGenre(Genre Genre)
        {
            try
            {
                if (Genre is null)
                {
                    throw new ArgumentNullException(nameof(Genre));
                }
                else
                {
                   return await _GenreService.Update(Genre);
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
