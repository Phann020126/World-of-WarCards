using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameProgram
{
    public class RandomPlayer : Handler
    {
        public RandomPlayer(Player player) : base(player) { }

        public override List<int> GetCards()
        {
            return PlayGenerator();
        }
    }
}