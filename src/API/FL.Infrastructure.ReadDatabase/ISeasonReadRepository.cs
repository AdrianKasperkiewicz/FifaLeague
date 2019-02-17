using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FL.Infrastructure.ReadDatabase
{
    public interface ISeasonReadRepository
    {
        Task<IList<SeasonViewModel>> GetSeasons();
    }

    public class SeasonViewModel
    {
        public SeasonViewModel()
        {
        }

        public SeasonViewModel(Guid id, string hierarchy, string name)
        {
            this.Id = id;
            this.Hierarchy = hierarchy;
            this.LeagueName = name;
            this.IsRunning = false;
        }

        public Guid Id { get; set; }

        public string Hierarchy { get; set; }

        public string LeagueName { get; set; }

        public bool IsRunning { get; set; }
    }

}
