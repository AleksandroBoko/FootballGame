using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Domain
{
    /// <summary>
    /// Игра
    /// </summary>
    class Game:IGame
    {
        const int MAX_PLAYERS = 11;
        public ITeam TeamFirst { get; private set; }
        public ITeam TeamSecond { get; private set; }
        public Person JudgeGame { get; private set; }
        public IMatchStatistic Statistic;


        public Game()
        {
            TeamFirst = new Team()
            {
                Name = "Barcelona",
                TeamTrainer = new Trainer() { FirstName = "Alex", LastName = "Takmakov" }
            };
            AddingPlayers(TeamFirst);

            TeamSecond = new Team()
            {
                Name = "Milan",
                TeamTrainer = new Trainer() { FirstName = "John", LastName = "Kontona" }
            };
            AddingPlayers(TeamSecond);

            JudgeGame = new Judge();
            Statistic = new MatchStatistic();
            
        }

        private void AddingPlayers(ITeam team)
        {
            for (int i = 0; i < MAX_PLAYERS; i++)
            {
                team.AddPlayer(new Player()
                {
                    FirstName = $"FirstName {i + 1}",
                    LastName = $"LastName {i + 1}",
                    Age = (new Random()).Next(16, 35)
                });
            }
        }

        public void StartMatch()
        {
            ShowBasicInfo();
            ShowResultOfMatch();
            ShowStatistic();
        }

        void ShowBasicInfo()
        {
            TeamFirst.SortPlayers();
            TeamSecond.SortPlayers();

            ShowTeamInfo(TeamFirst);
            Console.WriteLine();
            ShowTeamInfo(TeamSecond);
        }

        void ShowTeamInfo(ITeam team)
        {
            Team currentTeam = team as Team;
            if (currentTeam == null)
                return;

            Console.WriteLine($"Team: {currentTeam.Name}");
            Console.WriteLine($"Trainer: {currentTeam.TeamTrainer.FirstName} {currentTeam.TeamTrainer.LastName}");
            if (currentTeam.TeamTrainer is Trainer)
                Console.WriteLine($"Trainer's lucky: {((Trainer)currentTeam.TeamTrainer).LuckyLevel:f}");
            Console.WriteLine("The list of players:");
            currentTeam.Players.ForEach
                (
                    n => 
                    {
                        if (n is Player)
                            Console.WriteLine($"{n.FirstName} {n.LastName} - Age:{((Player)n).Age} - Level: {((Player)n).ProfessionalLevel}");
                    }
                    
                );
            Console.WriteLine($"Total level of team {currentTeam.LevelOfPlayers:f}");
        }

        void ShowResultOfMatch()
        {
            Team teamFirst = TeamFirst as Team;
            Team teamSecond = TeamSecond as Team;
            Judge judge = JudgeGame as Judge;

            if (teamFirst == null || teamSecond == null || judge == null)
            {
                return;
            }

            var valueOfFirstTeam = teamFirst.LevelOfPlayers;
            var valueOfSecondTeam = teamSecond.LevelOfPlayers;

            switch (judge.Behaviour)
            {
                case 1: valueOfFirstTeam = valueOfFirstTeam + valueOfFirstTeam * Judge.BONUS; break;
                case 2: valueOfSecondTeam = valueOfSecondTeam + valueOfSecondTeam * Judge.BONUS; break;
            }

            var coefForWin = 0.1;
            Console.WriteLine();
            if (valueOfFirstTeam > (valueOfSecondTeam + valueOfSecondTeam * coefForWin))
                Console.WriteLine($"The first team - {teamFirst.Name} has won!");
            else if(valueOfSecondTeam > (valueOfFirstTeam + valueOfFirstTeam * coefForWin))
                Console.WriteLine($"The second team - {teamSecond.Name} has won!");
            else
                Console.WriteLine("We didn't get the winner!");
        }

        private void ShowStatistic()
        {
            Console.WriteLine();
            Statistic.AddStatistic(() => Console.WriteLine("Statistic:"));
            Statistic.AddStatistic(() => Console.WriteLine($"Fouls: {Statistic.CountOfFouls}"));
            Statistic.AddStatistic(() => Console.WriteLine($"Yellow cards: {Statistic.CountOfYellowCards}"));
            Statistic.AddStatistic(() => Console.WriteLine($"Red cards: {Statistic.CountOfRedCards}"));
            Statistic.AddStatistic(() => Console.WriteLine($"Hits: {Statistic.CountOfHits}"));
            Statistic.ShowStatistic();
        }
    }
}
