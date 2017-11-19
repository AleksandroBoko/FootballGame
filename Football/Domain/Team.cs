using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Domain
{
    /// <summary>
    /// Команда
    /// </summary>
    class Team : ITeam
    {
        public List<Person> Players { get; private set; }
        public string Name { get; set; }
        public Person TeamTrainer { get; set; }
        public double LevelOfPlayers { get; set; }

        public Team()
        {
            Players = new List<Person>();            
            LevelOfPlayers = 0;
        }

        public void AddPlayer(Person person)
        {
            Players.Add(person);
            RefreshLevelOfPlayers();
        }

        public void AddTrainer(Person person)
        {
            TeamTrainer = person;
        }

        public List<Person> GetAllPlayers()
        {
            return Players;
        }

        public void SortPlayers()
        {
            Player temp;
            for (int i = 0; i < Players.Count - 1; i++)
            {
                for (int j = 0; j < Players.Count - 1; j++)
                {
                    var personFirst = Players[j] as Player;
                    var personSecond = Players[j + 1] as Player;
                    if (personFirst != null && personSecond != null)
                    {
                        if (personFirst.ProfessionalLevel < personSecond.ProfessionalLevel)
                        {
                            temp = personFirst;
                            Players[j] = personSecond;
                            Players[j + 1] = temp;
                        }

                    }
                }
            }
        }

        public void RefreshLevelOfPlayers()
        {
            if (TeamTrainer == null || Players == null || Players.Count == 0)
                return;

            Trainer trainer = TeamTrainer as Trainer;

            if (trainer == null)
                return;

            var levelPlayers = 0;
            for(int i = 0; i < Players.Count; i++)
            {
                Player p = Players[i] as Player;
                if(p != null)
                {
                    levelPlayers += p.ProfessionalLevel; 
                }
            }

            LevelOfPlayers = trainer.LuckyLevel * levelPlayers;
        }
    }
}
