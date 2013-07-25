using System;
using System.Collections.Generic;

namespace TicketSystem.Model
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }

        public Actor Actor { get; set; }
    }
}
