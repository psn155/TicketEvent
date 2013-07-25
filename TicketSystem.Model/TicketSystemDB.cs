using System.Data.Entity;
using System.Linq;

namespace TicketSystem.Model
{
    public class TicketSystemDB : DbContext, IDbContext
    {
        public TicketSystemDB()
            : base("name=DefaultConnection")
        {            
        }

        public void DisableProxyCreation()
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ArtType> ArtTypes { get; set; }

        IQueryable<Event> IDbContext.Events
        {
            get { return Events; }
        }

        IQueryable<Actor> IDbContext.Actors
        {
            get { return Actors; }
        }

        IQueryable<ArtType> IDbContext.ArtTypes
        {
            get { return ArtTypes; }
        }

        int IDbContext.SaveChanges()
        {
            return SaveChanges();
        }

        public T Attach<T>(T entity) where T : class
        {
            var entry = Entry(entity);
            entry.State = System.Data.EntityState.Modified;
            return entity;
        }

        public T Add<T>(T entity) where T : class
        {
            return Set<T>().Add(entity);
        }

        public T Delete<T>(T entity) where T : class
        {
            return Set<T>().Remove(entity);
        }
    }
}
