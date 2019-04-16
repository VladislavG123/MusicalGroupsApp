﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalGroupApp
{
    public class MusicalGroup : Entity
    {
        public string Name { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}