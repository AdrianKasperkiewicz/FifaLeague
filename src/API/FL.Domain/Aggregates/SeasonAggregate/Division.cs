using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate
{
    public class Division : Entity
    {
        private readonly List<Guid> teams;

        public Division(Guid guid, string name, int hierarchy, int numberOfDegraded, int numberOfPromoted)
        {
            base.Id = new Identity(guid);
            this.Name = name;
            this.Hierarchy = hierarchy;
            this.teams = new List<Guid>();
            this.NumberOfDegraded = numberOfDegraded;
            this.NumberOfPromoted = numberOfPromoted;
        }

        public int NumberOfPromoted { get; }

        public int NumberOfDegraded { get; }

        public string Name { get; }

        public int Hierarchy { get; }

        public ReadOnlyCollection<Guid> Teams => this.teams.AsReadOnly();

        internal void AddTeam(Guid teamId)
        {
            if (teamId == Guid.Empty)
            {
                throw new ArgumentException("Team Id could not be empty");
            }

            this.teams.Add(teamId);
        }
    }
}
