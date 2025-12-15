using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Kosarikov.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            Game game = new Game(random);
            game.Start();
        }
    }
}
