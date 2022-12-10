using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AST
{

    public class Boolean : AtomicExpression
    {
        public override NodeType Type { get => NodeType.Bool; set { } }
        public override object Value { get; set; }
        public override void Evaluate() { }
        public Boolean(double value, CodeLocation location) : base(location)
        {
            Value = value;
        }
    }
}