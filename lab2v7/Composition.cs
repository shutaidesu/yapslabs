﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2v7
{
    class Composition
    {
        private static int nextId = 1;
        public string Artist { get; set; }
        public string Title { get; set; }

        public int Id { get; set; }

        public Composition()
        {
            Id = nextId++;
        }

        public override string ToString()
        {
            return $"{Artist} - {Title}";
        }
    }
}
