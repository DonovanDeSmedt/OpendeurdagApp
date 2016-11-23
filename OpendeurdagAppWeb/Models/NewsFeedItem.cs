using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpendeurdagAppWeb.Models
{
    public class NewsFeedItem
    {
        public int NewsFeedItemId { get; set; }
        public string Title { get; set; }
        public string Inhoud { get; set; }
        public string Tag { get; set; }
        public DateTime Datum { get; set; }


    }
}