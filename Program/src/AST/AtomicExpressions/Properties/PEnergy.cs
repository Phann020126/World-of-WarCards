using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameProgram;

namespace AST
{
    public class PEnergy : Property
    {

        public override string Keyword => "energy";
        public override object Value { get; set; }
        public override List<NodeType> ExpectedTypes => new List<NodeType> { NodeType.Entity };

        public PEnergy(List<Node> parameters, CodeLocation location) : base(parameters, location)
        {
            Value = 0;
            Type = NodeType.Number;
        }

        public override void Evaluate()
        {
            Entity SelectedPlayer = (Entity)Parameters[0];

            SelectedPlayer.Evaluate();

            Player player = (Player)SelectedPlayer.Value;

            Value = player.Energy;
        }

        public override bool CheckSemantic(List<Error> errors)
        {
            return true;
        }

        public override string Description => $"{((Entity)Parameters[0]).Description}.Energy";
    }
}