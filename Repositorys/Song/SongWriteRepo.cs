using Abstractions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class SongWriteRepo : WriteRepo<Song>, ISongWriteRepo
    {
        DbContext _dbContext;
        public SongWriteRepo(DbContext context) : base(context)
        {
            _dbContext = context;
        }

        public void Add(Song model)
        {
            var artist = _dbContext.Artists.FirstOrDefault(a => a.Id == model.ArtistId);
            var genre = _dbContext.Genres.FirstOrDefault(g => g.Id == model.GenreId);

            if (genre == null)
                throw new Exception("There is no genre like that");

            if (artist == null)
                throw new Exception("There is no artist like that");

            model.Artist = artist;
            model.Genre = genre;
            artist.Songs.Add(model);
            genre.Songs.Add(model);

            Create(model);
        }
    }
}
