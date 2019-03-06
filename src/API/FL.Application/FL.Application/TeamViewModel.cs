using System;

namespace FL.Application
{
    public class TeamViewModel
    {
        public TeamViewModel()
        {
        }

        public TeamViewModel(Guid id, string email, string firstName, string lastName)
        {
            this.Id = id;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Guid Id { get; set; }

        public string Email { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}