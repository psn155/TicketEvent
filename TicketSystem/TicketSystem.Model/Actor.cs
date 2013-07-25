using System;
using System.Collections.Generic;

namespace TicketSystem.Model
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public ArtType ArtType { get; set; }
    }
}
