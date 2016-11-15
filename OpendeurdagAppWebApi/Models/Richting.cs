using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace OpendeurdagAppWebApi.Models
{
    public class Richting
    {
        public int RichtingId { get; set; }
        public string Omschrijving { get; set; }
        [ForeignKey("Campus")]
        public int Campus_Id { get; set; }
        public string Naam { get; set; }
        [JsonIgnore]
        public virtual Campus Campus { get; set; }
    }
}