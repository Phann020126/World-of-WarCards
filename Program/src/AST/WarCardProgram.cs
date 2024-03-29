using System;
using GameProgram;
namespace AST
{
    public class WarCardProgram : Node
    {
        public List<Error> Errors { get; private set; }
        public Dictionary<string, Card> Cards { get; private set; }
        public override string Description => GetDescription();
        public WarCardProgram(CodeLocation location) : base(location)
        {
            Errors = new List<Error>();
            Cards = new Dictionary<string, Card>();
        }
        public void AddCard(Card card)
        {
            // I have been thinking about this, and other option is : 
            //bool AddCard(Card card) and return false if the card already exists

            if (Cards.ContainsKey(card.Name))
            {
                //En este punto ya el contexto debe haber revisado eso
                //Errors.Add(new Error(ErrorCode.Invalid, card.Location, $"{card.Name} Card already exists"));
            }
            else
            {
                Cards.Add(card.Name, card);
            }
        }

        public void AddErrors(List<Error> errors)
        {
            Errors.AddRange(errors);
        }
        public override bool CheckSemantic(List<Error> errors)
        {
            foreach(Card card in Cards.Values)
            {
                if(!card.CheckSemantic(errors)) return false;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";
            foreach(string key in Cards.Keys)
            {
                s += key;
                s += "\n";
            }
            return s;
        }

        private string GetDescription()
        {
            string separator = '\n' + new string('*', 100) + '\n';

            string description = separator;

            foreach (Card card in Cards.Values)
            {
                description += card.Description;
                description += separator;
            }
            return description;
        }
    }
}