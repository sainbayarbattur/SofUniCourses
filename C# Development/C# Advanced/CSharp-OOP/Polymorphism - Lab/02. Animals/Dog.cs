using System;

namespace _02Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favoritefood)
            : base(name, favoritefood)
        {
        }

        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "DJAAF";
        }
    }
}