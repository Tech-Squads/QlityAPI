using Qlity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Qlity.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base ("DBConnect")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Gig> Gigs { get; set; }
    }
}