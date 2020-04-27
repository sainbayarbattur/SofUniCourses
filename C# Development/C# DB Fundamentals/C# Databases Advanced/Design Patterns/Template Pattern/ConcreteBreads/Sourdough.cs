namespace Template_Pattern.ConcreteBreads
{
    using System;

    class Sourdough : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for Sourdough bread");
        }

        public override void Bake()
        {
            Console.WriteLine("Bakeing the Sourdough Bread. (20 minutes)");
        }
    }
}
