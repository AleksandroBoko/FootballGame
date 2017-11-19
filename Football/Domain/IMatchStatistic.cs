using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Domain
{
    interface IMatchStatistic
    {
        int CountOfYellowCards { get; }
        int CountOfRedCards { get; }
        int CountOfFouls { get; }
        int CountOfHits { get; }

        void AddStatistic(Action action);
        void ShowStatistic();
    }
}
