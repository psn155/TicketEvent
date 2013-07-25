using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketSystem.Model
{
    public interface IDbContext
    {
        IQueryable<Event> Events { get; }
        IQueryable<Actor> Actors { get; }
        IQueryable<ArtType> ArtTypes { get; }

        int SaveChanges();
        T Attach<T>(T entity) where T : class;
        T Add<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;

        /// <summary>
        /// Disable change tracking and lazy loading by EF. 
        /// For Web API, we normally grab the data from the database and immediately return it to the client
        /// </summary>
        void DisableProxyCreation();
    }
}
