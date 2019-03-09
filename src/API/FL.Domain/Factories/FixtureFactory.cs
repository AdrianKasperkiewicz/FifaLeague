using System;
using System.Collections.Generic;
using System.Linq;

using FL.Domain.Aggregates.FixtureAggregate;

namespace FL.Domain.Factories
{
    public class FixtureFactory
    {
        private readonly Guid seasonId;

        private readonly Dictionary<Guid, Guid> teamsDivision;

        private readonly DateTime startDate;

        public FixtureFactory(Guid seasonId, Dictionary<Guid, Guid> teamsDivision, DateTime startDate)
        {
            this.seasonId = seasonId;
            this.teamsDivision = teamsDivision;
            this.startDate = startDate;
        }

        public List<WeekFixture> Build()
        {
            var result = new List<WeekFixture>();
            var divisions = this.teamsDivision.Values.Distinct();
            foreach (var division in divisions)
            {
                var teamsInDivision = this.teamsDivision
                    .Where(x => x.Value == division)
                    .Select(x => x.Key)
                    .ToList();

                result.AddRange(this.GenerateFixtureForDivision(teamsInDivision, division));
            }

            return result;
        }

        private IEnumerable<WeekFixture> GenerateFixtureForDivision(IList<Guid> teamList, Guid divisionId)
        {
            if (teamList.Count % 2 != 0)
            {
                teamList.Add(Guid.Empty);
            }

            var numDays = teamList.Count - 1;
            var halfSize = teamList.Count / 2;

            var teams = new List<Guid>();

            teams.AddRange(teamList); // Copy all the elements.
            teams.RemoveAt(0); // To exclude the first team.

            var teamsSize = teams.Count;
            var currentFixtureStartDate = this.startDate;

            for (var day = 0; day < numDays; day++)
            {
                var matches = new List<KeyValuePair<Guid, Guid>>();
                Console.WriteLine("Day {0}", day + 1);

                var teamIdx = day % teamsSize;
                matches.Add(new KeyValuePair<Guid, Guid>(teams[teamIdx], teamList[0]));
                Console.WriteLine("{0} vs {1}", teams[teamIdx], teamList[0]);

                for (var idx = 1; idx < halfSize; idx++)
                {
                    var firstTeam = (day + idx) % teamsSize;
                    var secondTeam = (day + teamsSize - idx) % teamsSize;
                    matches.Add(new KeyValuePair<Guid, Guid>(teams[firstTeam], teams[secondTeam]));
                    Console.WriteLine("{0} vs {1}", teams[firstTeam], teams[secondTeam]);
                }

                this.ClearEmptyMatches(matches);
                yield return new WeekFixture(
                    this.seasonId,
                    divisionId,
                    currentFixtureStartDate.Date,
                    currentFixtureStartDate.AddDays(7),
                    matches,
                    day + 1);
            }
        }

        private void ClearEmptyMatches(List<KeyValuePair<Guid, Guid>> matches)
        {
            matches.Remove(matches.FirstOrDefault(x => x.Value == Guid.Empty || x.Key == Guid.Empty));
        }
    }
}
