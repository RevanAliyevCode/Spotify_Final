﻿using Abstractions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class SongReadRepo : ReadRepo<Song>, ISongReadRepo
    {
        public SongReadRepo(DbContext context) : base(context)
        {
        }
    }
}
