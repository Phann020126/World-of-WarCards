using AST;


namespace GameProgram
{
    public class Card : Node
    {
        public string Name { get; private set; }
        public List<Effect> Effects { get; private set; }
        public Card(string name, List<Effect> effects, CodeLocation location) : base(location)
        {
            Name = name;
            Effects = effects;
            Location = location;
        }

        public void Play()
        {
            foreach (var effect in Effects)
            {
                effect.Evaluate();
            }
        }

        public override bool CheckSemantic(List<Error> errors)
        {
            foreach (var effect in Effects)
            {
                if (!effect.CheckSemantic(errors)) return false;
            }
            return true;
        }

        public override string ToString()
        {
            string str = "";
            foreach (Effect effect in Effects)
            {
                str += effect.Type + " ";
            }
            return Name + "( " + str + ")";
        }

        public Card Clone()
        {
            List<Effect> effectsClone = new List<Effect>();

            foreach (Effect effect in Effects)
            {
                effectsClone.Add(effect);
            }

            return new Card(Name, effectsClone, new CodeLocation());
        }

    }
}