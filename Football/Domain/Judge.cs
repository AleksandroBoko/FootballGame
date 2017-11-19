using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Domain
{
    /// <summary>
    /// Судья
    /// </summary>
    class Judge:Person
    {
        public const float BONUS = 0.1f;

        public int Behaviour { get; private set; }

        public Judge()
        {
            Random r = new Random();
            Behaviour = r.Next(0, 2);
        }
    }
}
