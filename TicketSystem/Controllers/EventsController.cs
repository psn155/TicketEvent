using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketSystem.Model;

namespace TicketSystem.Controllers
{
    public class EventsController : ApiController
    {
        #region # Dependencies and constructors #
        IDbContext _db;
          
        public EventsController(IDbContext db)
        {
            _db = db;
        }
        #endregion

        // GET api/events
        public IEnumerable<Event> Get()
        {
            _db.DisableProxyCreation();
            return _db.Events;
        }

        // GET api/events/5
        public Event Get(int id)
        {
            return _db.Events.SingleOrDefault(x => x.Id == id);
        }

        // POST api/events
        public HttpResponseMessage Post(Event anEvent)
        {
            if (ModelState.IsValid)
            {
                _db.Add<Event>(anEvent);
                try
                {
                    _db.SaveChanges();
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, anEvent);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = anEvent.Id }));
                    return response;
                }
                catch (DbUpdateException)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/events/5
        public HttpResponseMessage Put(int id, Event anEvent)
        {
            if (ModelState.IsValid && id == anEvent.Id)
            {
                try
                {
                    _db.Attach<Event>(anEvent);
                    _db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, anEvent);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.Conflict);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/events/5
        public HttpResponseMessage Delete(int id)
        {
            Event anEvent = _db.Events.FirstOrDefault(x => x.Id == id);
            if (anEvent == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            
            _db.Delete<Event>(anEvent);

            try
            {
                _db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, anEvent);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict);
            }
        }
    }
}
