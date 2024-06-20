using Models;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class PlaylistController
    {
        readonly PlaylistReadRepo _readRepo;
        readonly PlaylistWriteRepo _writeRepo;
        readonly SongReadRepo _songReadRepo;

        public PlaylistController(DbContext context)
        {
            _readRepo = new(context);
            _writeRepo = new(context);
            _songReadRepo = new(context);
        }

        public Playlist? GetByName(string name)
        {
            return _readRepo.GetAll().FirstOrDefault(p => p.Title == name);
        }

        public void Create(Playlist playlist)
        {
            _writeRepo.Create(playlist);
        }

        public void AddSongToPlaylist(int playlistId, int songId)
        {
            var playlist = _readRepo.GetById(playlistId);
            var song = _songReadRepo.GetAll().FirstOrDefault(s => s.Id == songId);
            if (playlist != null && song != null)
            {
                playlist.Songs.Add(song);
            }
        }

        public List<Playlist> GetByUser(int userId)
        {
            return _readRepo.GetAll().Where(p => p.UserID == userId).ToList();
        }

        public List<Playlist> GetAll()
        {
            return _readRepo.GetAll();
        }
    }
}

