namespace Prototype
{
    using Prototype.Models;
    using System;

    public class Program
    {
        public static void Main()
        {
            var sandiwchMenu = new SandwichMenu();

            sandiwchMenu["Italian"] = new Sandwich("White", "Bacon", "", "cucumber");
            sandiwchMenu["American"] = new Sandwich("White", "RawShit", "FrenchCheese", "Tomato");
            sandiwchMenu["German"] = new Sandwich("Rye", "Bacon", "", "cucumber");

            var s1 = sandiwchMenu["Italian"].Clone() as Sandwich;
            var s2 = sandiwchMenu["American"].Clone() as Sandwich;
            var s3 = sandiwchMenu["German"].Clone() as Sandwich;
        }
    }
}
