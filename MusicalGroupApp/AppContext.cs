namespace MusicalGroupApp
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AppContext : DbContext
    {
        public AppContext()
            : base("name=AppContext")
        {
        }

        public DbSet<MusicalGroup> MusicalGroups { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}