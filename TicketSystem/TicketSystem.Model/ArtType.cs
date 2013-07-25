using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketSystem.Model
{
    public class ArtType
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
    }
}
