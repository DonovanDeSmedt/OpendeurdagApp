using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpendeurdagAppWeb.Models;

namespace OpendeurdagAppWeb.Models
{
    public class Campus
    {
        public int CampusId { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public virtual ICollection<Richting> Richtingen { get; set; }
        public virtual ICollection<Gebouw> Gebouwen { get; set; }
        public string Foto { get; set; }
    }
}