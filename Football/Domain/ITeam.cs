using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Domain
{
    interface ITeam
    {
        void AddPlayer(Person person);
        List<Person> GetAllPlayers();
        void SortPlayers();
    }
}
