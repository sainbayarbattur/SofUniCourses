using System;
using Template_Pattern.ConcreteBreads;

namespace Template_Pattern
{
    public class Program
    {
        public static void Main()
        {
            var b1 = new Sourdough();
            var b2 = new TwelveGrain();
            var b3 = new WholeWheat();

            b1.Make();
            b2.Make();
            b3.Make();
        }
    }
}
