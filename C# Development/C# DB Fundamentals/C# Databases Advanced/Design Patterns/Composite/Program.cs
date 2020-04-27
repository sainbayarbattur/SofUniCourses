namespace Composite
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var phone = new SingleGift("IPhone X", 2000);
            phone.CalculateTotalPrice();

            Console.WriteLine();

            var root = new CompositeGift("RootBox", 0);

            root.Add(new SingleGift("Laptop", 3000));
            root.Add(new SingleGift("MousePad", 20));
            root.Add(new SingleGift("Something", 300));
            root.Add(new SingleGift("d", 5));

            Console.WriteLine("Total price: " + root.CalculateTotalPrice());
        }
    }
}
