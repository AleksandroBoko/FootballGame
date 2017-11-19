using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Football.Domain
{
    /// <summary>
    /// Футболист
    /// </summary>
    class Player:Person
    {
        public int ProfessionalLevel { get; private set; }
        public int Age { get; set; }

        public Player()
        {
            Random r = new Random();
            ProfessionalLevel = r.Next(0,100);
            Thread.Sleep(50);
        }
    }
}
