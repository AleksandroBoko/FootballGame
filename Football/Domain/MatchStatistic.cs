using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Domain
{
    class MatchStatistic : IMatchStatistic
    {
        Action Statistic;

        public int CountOfYellowCards { get; private set; }
        public int CountOfRedCards { get; private set; }
        public int CountOfFouls { get; private set; }
        public int CountOfHits { get; private set; }

        public MatchStatistic()
        {
            CountOfFouls = (new Random()).Next(0, 10);
            CountOfYellowCards = (new Random()).Next(0, CountOfFouls);
            CountOfRedCards = (new Random()).Next(0, CountOfYellowCards);
            CountOfHits = (new Random()).Next(1,30);
        }

        public void AddStatistic(Action action)
        {
            if (Statistic == null)
                Statistic = action;
            else
                Statistic += action;
        }

        public void ShowStatistic()
        {
            if (Statistic != null)
                Statistic();
        }
    }
}
