using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Domain
{
    /// <summary>
    /// Тренер
    /// </summary>
    class Trainer:Person
    {
        public double LuckyLevel { get; private set; }

        public Trainer()
        {
            Random r = new Random();
            LuckyLevel = r.NextDouble()+0.5;
        }

    }
}
