namespace Template_Pattern.ConcreteBreads
{
    using System;

    class TwelveGrain : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for 12-Grain bread");
        }

        public override void Bake()
        {
            Console.WriteLine("Bakeing the TwelveGrain Bread. (25 minutes)");
        }
    }
}
