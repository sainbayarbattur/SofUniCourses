namespace _02Animals
{
    public class Animal
    {
        protected Animal(string name, string favoritefood)
        {
            this.Name = name;
            this.FavoriteFood = favoritefood;
        }

        public string Name { get; }

        public string FavoriteFood { get; }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my favourite food is {this.FavoriteFood}";
        }
    }
}