namespace TicketSystem.Model.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TicketSystem.Model.TicketSystemDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;            
        }

        protected override void Seed(TicketSystem.Model.TicketSystemDB context)
        {
            List<Actor> actors = new List<Actor>(){
                new Actor
                        {
                            FirstName = "Nguyen",
                            MiddleName = "Si",
                            LastName = "Pham",
                            IsActive = true,
                            Gender = "Male"
                        },
                new Actor
                        {
                            FirstName = "Trang",
                            MiddleName = "Hanh",
                            LastName = "Tran",
                            IsActive = true,
                            Gender = "Female"             
                        },
                new Actor
                        {
                            FirstName = "My",
                            MiddleName = "Ngoc",
                            LastName = "Pham",
                            IsActive = true,
                            Gender = "Female"             
                        }};
            ArtType music = new ArtType
                {
                    Name = "Music",
                    Description = "Music is all",
                    IsActive = true,
                    Actors = actors.Where(x=> x.FirstName == "Nguyen").ToList()
                };
            ArtType sport = new ArtType
                {
                    Name = "Sport",
                    Description = "Sport",
                    IsActive = true,
                    Actors = actors.Where(x=> x.FirstName == "Trang").ToList()                    
                };
            ArtType comedy = new ArtType
                {
                    Name = "Comedy",
                    Description = "Comedy",
                    IsActive = true,
                    Actors = actors.Where(x=> x.FirstName == "My").ToList()
                };
            context.ArtTypes.AddOrUpdate(r => r.Name,
                music, sport, comedy);


            Event event1 = new Event
            {
                Name = "Nguyen Music Night",
                Location = "Melbourne",
                IsActive = true,
                Date = DateTime.Now,
                Description = "This is the night of music",
                Actor = actors.Single(x => x.FirstName == "Nguyen")
            };
            Event event2 = new Event
            {
                Name = "Trang Sport Performance",
                Location = "Sydney",
                IsActive = true,
                Date = DateTime.Now.AddDays(2),
                Description = "Come and see my performance",
                Actor = actors.Single(x => x.FirstName == "Trang")
            };
            context.Events.AddOrUpdate(x => x.Name,
                event1, event2);
        }
    }
}
