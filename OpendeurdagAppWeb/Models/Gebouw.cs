using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OpendeurdagAppWeb.Models
{
    public class Gebouw
    {
        public int GebouwId { get; set; }
        [ForeignKey("Campus")]
        public int Campus_Id { get; set; }
        public string Naam { get; set; }
        [JsonIgnore]
        public virtual Campus Campus { get; set; }
    }
}