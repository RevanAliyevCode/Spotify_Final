﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BaseModel
    {
        private static int _id = 0;
        public int Id { get; set; }

        public BaseModel()
        {
            Id = ++_id;
        }

        public virtual void GetDetail()
        {

        }
    }
}
