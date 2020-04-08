using System.Collections.Generic;

namespace WildFarm
{
    public interface IAnimal
    {
        string Name { get; set; }

        double Weight { get; set; }

        int FoodEaten { get; set; }

        List<Food> Foods { get; set; }

        void Eat(string typeOfFood, int quantity);

        string ProduceSound();
    }
}