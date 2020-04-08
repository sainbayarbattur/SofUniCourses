namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Animals.Birds;
    using WildFarm.Animals.Mammals;
    using WildFarm.Animals.Mammals.Felines;

    public class Program
    {
        public static void Main()
        {
            var result = new StringBuilder();

            var animalList = new List<Animal>();

            var typeOfAnimals = new Dictionary<string, List<string>>();

            AddTypes(typeOfAnimals);

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;

                string[] animalToken = input.Split(' ');

                string type = animalToken[0];

                input = Console.ReadLine();

                string[] token = input.Split(' ');

                string typeOfFood = token[0];
                int quantity = int.Parse(token[1]);

                try
                {
                    // Birds
                    if (typeOfAnimals["Bird"].Contains(type))
                    {
                        string name = animalToken[1];
                        double animalWeight = double.Parse(animalToken[2]);
                        double wingSize = double.Parse(animalToken[3]);

                        switch (type)
                        {
                            case "Owl":
                                Owl owl = new Owl(name, animalWeight, wingSize);
                                result.AppendLine(owl.ProduceSound());
                                animalList.Add(owl);
                                owl.Eat(typeOfFood, quantity);
                                break;
                            case "Hen":
                                Hen hen = new Hen(name, animalWeight, wingSize);
                                result.AppendLine(hen.ProduceSound());
                                animalList.Add(hen);
                                hen.Eat(typeOfFood, quantity);
                                break;
                        }
                    }

                    // Mammals
                    if (typeOfAnimals["Mammal"].Contains(type))
                    {
                        string mammalName = animalToken[1];
                        double mammalAnimalWeight = double.Parse(animalToken[2]);
                        string mammalLivingRegion = animalToken[3];

                        switch (type)
                        {
                            case "Mouse":
                                Mouse mouse = new Mouse(mammalName, mammalAnimalWeight, mammalLivingRegion);
                                animalList.Add(mouse);
                                result.AppendLine(mouse.ProduceSound());
                                mouse.Eat(typeOfFood, quantity);
                                break;
                            case "Dog":
                                Dog dog = new Dog(mammalName, mammalAnimalWeight, mammalLivingRegion);
                                result.AppendLine(dog.ProduceSound());
                                animalList.Add(dog);
                                dog.Eat(typeOfFood, quantity);
                                break;
                        }
                    }

                    // Feline 
                    if (typeOfAnimals["Feline"].Contains(type))
                    {
                        string felineName = animalToken[1];
                        double felineWeight = double.Parse(animalToken[2]);
                        string felineLivingRegion = animalToken[3];
                        string felineBreed = animalToken[4];

                        switch (type)
                        {
                            case "Cat":
                                Cat cat = new Cat(felineName, felineWeight, felineLivingRegion, felineBreed);
                                animalList.Add(cat);
                                result.AppendLine(cat.ProduceSound());
                                cat.Eat(typeOfFood, quantity);
                                break;
                            case "Tiger":
                                Tiger tiger = new Tiger(felineName, felineWeight, felineLivingRegion, felineBreed);
                                animalList.Add(tiger);
                                result.AppendLine(tiger.ProduceSound());
                                tiger.Eat(typeOfFood, quantity);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.AppendLine(ex.Message);
                }
            }

            Console.Write(result.ToString());

            foreach (var animal in animalList)
            {
                Console.WriteLine(animal);
            }
        }

        public static void AddTypes(Dictionary<string, List<string>> typeOfAnimals)
        {
            typeOfAnimals.Add("Bird", new List<string>());
            typeOfAnimals["Bird"].Add("Owl");
            typeOfAnimals["Bird"].Add("Hen");
            typeOfAnimals.Add("Mammal", new List<string>());
            typeOfAnimals["Mammal"].Add("Mouse");
            typeOfAnimals["Mammal"].Add("Dog");
            typeOfAnimals.Add("Feline", new List<string>());
            typeOfAnimals["Feline"].Add("Cat");
            typeOfAnimals["Feline"].Add("Tiger");
        }
    }
}