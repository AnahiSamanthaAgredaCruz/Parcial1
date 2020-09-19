using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ParcialAnahiAgreda.Models
{
    public class DataContext: DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<ParcialAnahiAgreda.Models.AnahiAgreda> AnahiAgredas { get; set; }
    }
}