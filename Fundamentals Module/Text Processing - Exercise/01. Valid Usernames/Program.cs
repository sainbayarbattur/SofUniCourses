namespace ValidUsernames
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(", ").ToList();
            var result = new List<string>();
            //string[] alpha = {"A","a","B","b","C","c","D","d","E","e","F","f","G","g","H","h","I",
            //"i","J","j","K","k","L","l","M","m","N","n","O","o","P","p","Q","q","R","r","S","s",
            //"T","t","U","u","V","v","Q","q","X","x","Y","y","Z","z","-","_","1","2","3","4","5","6","7","8","9","0"};

            //string alpha1 = "A a B b C c D d E e F f G g H h I i J j K k L l M m N n O o P p Q q R r S s T t U u V v Q q X x Y y Z z - _ 1 2 3 4 5 6 7 8 9 0";

            char[] alpha2 = { 'A','a','B','b','C','c','D','d','E','e','F','f','G','g','H','h','I',
                'i','J','j','K','k','L','l','M','m','N','n','O','o','P','p','Q','q','R','r','S','s',
                'T','t','U','u','V','v','Q','q','X','x','Y','y','Z','z','-','_','1','2','3','4','5','6','7','8','9','0'};

            bool allWord = false;

            for (int i = 0; i < input.Count; i++)
            {
                string currWord = input[i];
                
                if (currWord.Length >= 3 && currWord.Length <= 16)
                {
                    for (int b = 0; b < currWord.Length; b++)
                    {
                        if (char.IsLetterOrDigit(currWord[b]) || currWord[b] == '_' || currWord[b] == '-')
                        {
                            allWord = true;
                        }
                        else
                        {
                            allWord = false;
                            break;
                        }
                    }
                    if (allWord == true)
                    {
                        result.Add(input[i]);
                    }
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
