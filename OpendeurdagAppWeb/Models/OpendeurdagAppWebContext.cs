using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OpendeurdagAppWeb.Models
{
    public class OpendeurdagAppWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public OpendeurdagAppWebContext() : base("name=OpendeurdagAppWebContext")
        {
        }

        public System.Data.Entity.DbSet<OpendeurdagAppWeb.Models.Campus> Campus { get; set; }

        public System.Data.Entity.DbSet<OpendeurdagAppWeb.Models.Gebouw> Gebouws { get; set; }

        public System.Data.Entity.DbSet<OpendeurdagAppWeb.Models.Richting> Richtings { get; set; }

        public System.Data.Entity.DbSet<OpendeurdagAppWeb.Models.NewsFeedItem> NewsFeedItems { get; set; }
    }
}
