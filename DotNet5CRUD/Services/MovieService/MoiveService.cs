using DotNet5CRUD.Models;
using DotNet5CRUD.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNet5CRUD.Services.MovieService
{
    public class MoiveService : IMoiveService
    {
        private readonly IGenericRepo<Movie> _movieService;
        public MoiveService(IGenericRepo<Movie> movieService)
        {
            _movieService = movieService;
        }

        public async Task addMovie(Movie movie)
        {
            try
            {
                if (movie is null)
                {
                    throw new ArgumentNullException(nameof(movie));
                }
                else
                {
                    await _movieService.Add(movie);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task deleteMovie(int id)
        {
            try
            {
                await _movieService.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Movie>> GetAllMovies(string[] includes = null)
        {
            try
            {
                return await _movieService.GetAllEntries(includes);
            }
            catch (Exception)
            {
                throw new Exception("Error , for get all Movies, try again later plz");
            }
        }

        public async Task<IEnumerable<Movie>> GetAllMovies<TKey>(Expression<Func<Movie, TKey>> orderBy = null, string[] includes = null)
        {
            try
            {
                return await _movieService.GetAllEntries(orderBy,includes);
            }
            catch (Exception)
            {
                throw new Exception("Error , for get all Movies, try again later plz");
            }
        }

        public async Task<Movie> GetMovieByID(int MovieId)
        {
            return await _movieService.GetByID(MovieId);
        }

        public async Task<Movie> updateMovie(Movie movie)
        {
            try
            {
                if (movie is null)
                {
                    throw new ArgumentNullException(nameof(movie));
                }
                else
                {
                   return await _movieService.Update(movie);
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
