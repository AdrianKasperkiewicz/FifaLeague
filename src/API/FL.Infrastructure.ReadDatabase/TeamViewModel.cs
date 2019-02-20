using System;

namespace FL.Infrastructure.ReadDatabase
{
    public class TeamViewModel
    {
        public TeamViewModel() { }

        public TeamViewModel(Guid id, string email, string name)
        {
            this.Id = id;
            this.Email = email;
            this.Name = name;
            this.LeagueName = string.Empty;
        }

        public Guid Id { get; set; }

        public string Email { get; private set; }

        public string Name { get; private set; }

        public string LeagueName { get; private set; }

        public Guid? LeagueGuid { get; private set; }
    }

}
