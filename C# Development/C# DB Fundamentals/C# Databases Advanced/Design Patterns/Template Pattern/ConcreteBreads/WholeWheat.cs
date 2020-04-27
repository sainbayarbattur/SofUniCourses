namespace Template_Pattern.ConcreteBreads
{
    using System;

    public class WholeWheat : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for WholeWheat bread");
        }

        public override void Bake()
        {
            Console.WriteLine("Bakeing the TwelveGrain Bread. (20 minutes)");
        }

        public override void Slice()
        {
            base.Slice();
        }
    }
}
