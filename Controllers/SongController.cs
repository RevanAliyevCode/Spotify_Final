using Models;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class SongController
    {
        readonly SongReadRepo _readRepo;
        readonly SongWriteRepo _writeRepo;

        public SongController(DbContext context)
        {
            _readRepo = new(context);
            _writeRepo = new(context);
        }

        public List<Song> GetAll()
        {
            return _readRepo.GetAll();
        }

        public Song? GetSongById(int id)
        {
            Song? song = _readRepo.GetById(id);
            if (song is not null)
            {
                song.GetDetail();
                return song;
            }
            Console.WriteLine("There is no song with that id");
            return null;
        }

        public void GetByInput(string input)
        {
            List<Song> songs = _readRepo.GetAll().FindAll(s => s.Title.ToLower().Contains(input.ToLower()));

            foreach (Song song in songs)
            {
                Console.WriteLine($"{song.Title} - {song.Artist.Name}");
            }
        }

        public void AddSong(Song song)
        {
            _writeRepo.Add(song);
        }

        public void DeleteSong(int id)
        {
            _writeRepo.Delete(id);
        }

        public void UpdateSong(int id, Song song)
        {
            _writeRepo.Update(id, song);
        }
    }
}
