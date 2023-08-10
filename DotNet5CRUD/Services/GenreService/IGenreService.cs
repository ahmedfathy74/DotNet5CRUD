using DotNet5CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNet5CRUD.Services.GenreService
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllGenres(string[]? includes = null);

        Task<IEnumerable<Genre>> GetAllGenres<TKey>(Expression<Func<Genre, TKey>> orderBy = null, string[] includes = null);

        Task addGenre(Genre genre);
        Task<Genre> updateGenre(Genre genre);
        Task deleteGenre(int id);
        Task<Genre> GetGenreByID(int genreId);
    }
}
