namespace Animals
{
    using global::Animals.Animals;
    using System;
    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                string command = Console.ReadLine();

                string type = command;

                if (command == "Beast!")
                {
                    break;
                }

                command = Console.ReadLine();

                string name = command.Split(' ')[0];
                int age = int.Parse(command.Split(' ')[1]);
                string gender = command.Split(' ')[2];

                Animal animal;

                if (type == "Cat")
                {
                    animal = new Cat(name, age, gender);
                }
                else if (type == "Dog")
                {
                    animal = new Dog(name, age, gender);
                }
                else if (type == "Frog")
                {
                    animal = new Frog(name, age, gender);
                }
                else if (type == "Kitten")
                {
                    animal = new Kitten(name, age);
                }
                else if (type == "Tomcat")
                {
                    animal = new Tomcat(name, age);
                }
                else
                {
                    throw new Exception("Invalid Input!");
                }

                Console.WriteLine(animal);
            }
        }
    }
}
