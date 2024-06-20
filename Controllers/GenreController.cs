using Models;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class GenreController
    {
        readonly GenreWriteRepo _writeRepo;
        readonly GenreReadRepo _readRepo;

        public GenreController(DbContext context)
        {
            _writeRepo = new(context);
            _readRepo = new(context);
        }

        public void GetAllGenre()
        {
            foreach (Genre genre in _readRepo.GetAll())
            {
                Console.WriteLine($"{genre.Name}");
            }
        }

        public Genre? GetGenreById(int id)
        {
            Genre? genre = _readRepo.GetById(id);
            if (genre is not null)
            {
                genre.GetDetail();
                return genre;
            }
            Console.WriteLine("There is no genre with that id");
            return null;
        }

        public void GetByInput(string input)
        {
            List<Genre> genres = _readRepo.GetAll().FindAll(a => a.Name.ToLower().Contains(input.ToLower()));

            foreach (Genre genre in genres)
            {
                Console.WriteLine($"{genre.Name}");
            }
        }

        public void AddGenre(Genre genre)
        {
            _writeRepo.Create(genre);
        }

        public void DeleteGenre(int id)
        {
            _writeRepo.Delete(id);
        }

        public void UpdateGenre(int id, Genre genre)
        {
            _writeRepo.Update(id, genre);
        }
    }
}
