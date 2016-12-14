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
        private static List<Gebouw> listGebouwen = new List<Gebouw> { new Gebouw() { Naam = "B", Foto = "ms-appx:///Assets/building.png" }, new Gebouw() { Naam = "C", Foto = "ms-appx:///Assets/building.png" }, new Gebouw() { Naam = "D", Foto = "ms-appx:///Assets/building.png" }, new Gebouw() { Naam = "P", Foto = "ms-appx:///Assets/building.png" } };
        private static Campus schoonmeersen = new Campus()
        {
            Adres = "Valentin Vaerweglaan 9000 Gent",
            Naam = "Campus Schoonmeersen",
            Richtingen = listRichtingen,
            Foto = "ms-appx:///Assets/schoonmeersen.jpg",
            Gebouwen = listGebouwen
        };
        private static Campus ledeganck = new Campus()
        {
            Adres = "Centrum 9000 Gent",
            Naam = "Campus Ledeganck",
            Richtingen = listRichtingen,
            Foto = "ms-appx:///Assets/ledeganck.jpg",
            Gebouwen = listGebouwen
        };
        private static List<NewsfeedItem> listNewsFeed = new List<NewsfeedItem>
        {
            new NewsfeedItem() {Datum = new DateTime(2016, 11, 10),Inhoud = "Mensen, kom dit zien kom dit zien, bickies aan een euro aan de D-resto", Title = "Bickies aan een euro",Tag = "FOOD" },
            new NewsfeedItem() {Datum = new DateTime(2016, 11, 10),Inhoud = "Mensen, kom dit zien kom dit zien, bickies aan twee euro aan de D-resto", Title = "Bickies aan twee euro",Tag = "FAST" },
            new NewsfeedItem() {Datum = new DateTime(2016, 11, 10),Inhoud = "Mensen, kom dit zien kom dit zien, bickies aan drie euro aan de D-resto", Title = "Bickies aan drie euro",Tag = "ONGEZOND" },
            new NewsfeedItem() {Datum = new DateTime(2016, 11, 10),Inhoud = "Mensen, kom dit zien kom dit zien, bickies aan vier euro aan de D-resto", Title = "Bickies aan vier euro",Tag = "RESTO" }
        };


        public static List<Campus> GetCampussen()
        {
            return new List<Campus>{ledeganck, schoonmeersen};
        }

        public static List<NewsfeedItem> GetNewsFeed()
        {
            return listNewsFeed;
        }
    }
}
