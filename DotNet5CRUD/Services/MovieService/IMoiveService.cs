using DotNet5CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNet5CRUD.Services.MovieService
{
    public interface IMoiveService
    {
        Task<IEnumerable<Movie>> GetAllMovies(string[]? includes = null);
        Task<IEnumerable<Movie>> GetAllMovies<TKey>(Expression<Func<Movie, TKey>> orderBy = null, string[] includes = null);
        Task addMovie(Movie movie);
        Task<Movie> updateMovie(Movie movie);
        Task deleteMovie(int id);
        Task<Movie> GetMovieByID(int MovieId);
    }
}
