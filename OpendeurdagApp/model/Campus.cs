﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpendeurdagApp.Model
{
    public class Campus
    {
        public string Adres { get; set; }
        public string Naam { get; set; }
        public List<Richting> Richtingen { get; set; }
        public string Foto { get; set; }
    }
}
