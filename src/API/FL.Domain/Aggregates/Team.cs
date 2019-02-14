using System;

namespace FL.Domain
{
    public class Team
    {
        public Team(string name, string email)
        {
            this.Name = name;
            this.IsActive = true;
            this.Email = email;
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public string Name { get; }

        public string Email { get; }

        public bool IsActive { get; }
    }
}