﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class TreeViewNode
    {
        public string id { get; set; }
        public string parent { get; set; }
        public string text { get; set; }

        public string icon { get; set; }

        public state state { get; set; }

    }

    public class state
    {
        public bool disabled { get; set; }
    }

}
