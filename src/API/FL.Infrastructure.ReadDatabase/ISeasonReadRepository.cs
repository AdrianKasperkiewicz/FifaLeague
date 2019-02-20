using System;
using System.Collections.Generic;
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

        public SeasonViewModel(Guid id)
        {
            this.Id = id;
            this.IsRunning = false;
            this.Number = 1;
        }

        public Guid Id { get; set; }

        public bool IsRunning { get; set; }

        public int Number { get; set; }
    }

}
