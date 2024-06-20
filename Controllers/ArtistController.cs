using Models;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ArtistController
    {
        readonly ArtistReadRepo _readRepo;
        readonly ArtistWriteRepo _writeRepo;

        public ArtistController(DbContext context)
        {
            _readRepo = new(context);
            _writeRepo = new(context);
        }

        public void GetAllArtists()
        {
            foreach (Artist artist in _readRepo.GetAll())
            {
                Console.WriteLine($"{artist.Name}");
            }
        }

        public Artist? GetArtistById(int id)
        {
            Artist? artist = _readRepo.GetById(id);
            if (artist is not null)
            {
                artist.GetDetail();
                return artist;
            }
            Console.WriteLine("There is no artist with that id");
            return null;
        }

        public void GetByInput(string input)
        {
            List<Artist> artists = _readRepo.GetAll().FindAll(a => a.Name.ToLower().Contains(input.ToLower()));

            foreach (Artist artist in artists)
            {
                Console.WriteLine($"{artist.Name}");
            }
        }

        public void AddArtist(Artist artist)
        {
            _writeRepo.Create(artist);
        }

        public void DeleteArtist(int id)
        {
            _writeRepo.Delete(id);
        }

        public void UpdateArtist(int id, Artist artist)
        {
            _writeRepo.Update(id, artist);
        }
    }
}
