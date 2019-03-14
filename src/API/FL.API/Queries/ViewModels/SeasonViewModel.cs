using System;

namespace FL.API.Queries.ViewModels
{
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

        public DateTime StartDate { get; set; }
    }
}