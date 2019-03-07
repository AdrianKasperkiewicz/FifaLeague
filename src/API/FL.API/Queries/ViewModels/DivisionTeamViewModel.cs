using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FL.API.Queries.ViewModels
{
    public class DivisionTeamViewModel
    {
        public Guid Id { get; set; }

        public Guid DivisionId { get; set; }

        public Guid TeamId { get; set; }

        public string FullTeamName { get; set; }

        public string Email { get; set; }
    }
}
