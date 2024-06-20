using Abstractions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class PlaylistWriteRepo : WriteRepo<Playlist>, IPlaylistWriteRepo
    {
        DbContext _dbContext;
        public PlaylistWriteRepo(DbContext context) : base(context)
        {
            _dbContext = context;
        }

        public new void Create(Playlist model)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == model.UserID);

            if (user == null)
                throw new Exception("There is no user like that");

            model.User = user;
            user.Playlists.Add(model);

            base.Create(model);
        } 
    }
}
