using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TicketSystem.Model;

namespace TicketSystem.Repository
{
    public class TicketSystemDb : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ArtType> ArtTypes { get; set; }
    }
}
