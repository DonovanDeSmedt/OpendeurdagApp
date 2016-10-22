using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpendeurdagApp.model
{
    class Opleiding
    {

        public string Naam { get; set; }
        public string Beschrijving { get; set; }

        public Opleiding(string naam,string beschrijving)
        {
            this.Naam = naam;
            this.Beschrijving = beschrijving;
            
        }
    }
}
