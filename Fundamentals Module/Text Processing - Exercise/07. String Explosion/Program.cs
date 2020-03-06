namespace SecondStringExplosion
{
    using System;
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string result = string.Empty;
            bool bomb = false;
            int power = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char curr = input[i];
                if (curr == '>')
                {
                    bomb = true;
                    power += int.Parse(input[i + 1].ToString());
                    result += curr;
                    continue;
                }
                if (bomb && power > 0)
                {
                    power -= 1;
                    if (power <= 0)
                    {
                        bomb = false;
                        power = 0;
                    }
                    continue;
                }
                if (bomb == false)
                {
                    result += curr;
                }
            }

            Console.WriteLine(result);
        }
    }
}
