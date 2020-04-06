namespace Restaurant.Foods
{
    public class Fish : MainDish
    {
        const double fishGrams = 22;

        public Fish(string name, decimal price) 
            : base(name, price, fishGrams)
        {   
        }
    }
}
