using Football.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    class Program
    {
        static IGame GameFootball;

        static void Main(string[] args)
        {
            GameFootball = new Game();
            GameFootball.StartMatch();

            Console.ReadKey();
        }
    }
}
