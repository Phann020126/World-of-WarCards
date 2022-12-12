using System;
using GameProgram;
namespace AST
{
    public class WarCardProgram : Node
    {
        public List<Error> Errors { get; private set; }
        public Dictionary<string, Card> Cards { get; private set; }
        public WarCardProgram(CodeLocation location) : base(location)
        {
            Errors = new List<Error>();
            //aqui vendrian la inicializacion de los diccionarios correspondientes
        }
        public void AddCard(Card card)
        {
            // I have been thinking about this, and other option is : 
            //bool AddCard(Card card) and return false if the card already exists

            if (Cards.ContainsKey(card.Name))
            {
                Errors.Add(new Error("Card " + card.Name + " already exists", card.Location));
            }
            else
            {
                Cards.Add(card.Name, card);
            }
        }

        public void AddError(Error error)
        {
            Errors.Add(error);
        }
        public override bool CheckSemantic(List<Error> errors)
        {
            throw new Exception("CheckSemantic was't implemented");
        }

    }
}