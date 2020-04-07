namespace PizzaCalories
{
    using System;
    public class Program
    {
        public static void Main()
        {
            try
            {
                double allCalories = 0;
                string pizzaInput = Console.ReadLine();
                string[] pizzaToken = pizzaInput.Split();
                if (string.IsNullOrWhiteSpace(pizzaToken[1]) || pizzaToken[1].Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                var pizza = new Pizza(pizzaToken[1]);

                string doughInput = Console.ReadLine();
                string[] doughToken = doughInput.Split();

                string flourType = doughToken[1];
                string bakingTechnique = doughToken[2];
                double weightDough = double.Parse(doughToken[3]);

                var dough = new Dough(flourType, bakingTechnique, weightDough);
                dough.ClaculateCalories();
                allCalories += dough.Calories;

                string toppingInput = Console.ReadLine();

                while (toppingInput != "END")
                {
                    string[] toppingToken = toppingInput.Split();

                    string type = toppingToken[1];
                    double weightTopping = double.Parse(toppingToken[2]);

                    var topping = new Topping(type, weightTopping);
                    pizza.Toppings(topping);
                    topping.CalculateCalories();
                    allCalories += topping.Calories;

                    toppingInput = Console.ReadLine();
                }
                Console.WriteLine($"{pizzaToken[1]} - {allCalories:f2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
