using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpendeurdagApp.Model.DAL
{
    public static class CampusRepository
    {
        private static List<Richting> listRichtingen = new List<Richting> { new Richting() { Naam = "Toegepaste informatica" }, new Richting() { Naam = "Bedrijfsmanagement" } };
        private static Campus schoonmeersen = new Campus()
        {
            Adres = "Valentin Vaerweglaan 9000 Gent",
            Naam = "Campus Schoonmeersen",
            Richtingen = listRichtingen,
            Foto = "ms-appx:///Assets/schoonmeersen.jpg"
        };
        private static Campus ledeganck = new Campus()
        {
            Adres = "Centrum 9000 Gent",
            Naam = "Campus Ledeganck",
            Richtingen = listRichtingen
        };
        public static List<Campus> GetCampussen()
        {
            return new List<Campus>{ledeganck, schoonmeersen};
        }
    }
}
