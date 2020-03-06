namespace PasswordValidator
{
    using System;
    public class Program
    {
        public static void Main()
        {
            string password = Console.ReadLine();

            if (CharactersCheck(password) == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (LettersDigitsCheck(password) == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (DigitsCheck(password) == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (CharactersCheck(password) && DigitsCheck(password) && LettersDigitsCheck(password))
            {
                Console.WriteLine("Password is valid");
            }
            Console.Read();
        }

        public static bool CharactersCheck(string pass)
        {
            bool isValidCharacter = true;

            if (pass.Length >= 6 && pass.Length <= 10)
            {
                isValidCharacter = true;
            }
            else
            {
                isValidCharacter = false;
            }

            return isValidCharacter;
        }

        public static bool DigitsCheck(string pass)
        {
            bool isValidDigits = false;
            char[] digits = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            int count = 0;

            for (int i = 0; i < pass.Length; i++)
            {
                for (int b = 0; b < digits.Length ;b++)
                {
                    if (pass[i] == digits[b])
                    {
                        count++;
                        if (count == 2)
                        {
                            isValidDigits = true;
                            break;
                        }
                        else
                        {
                            isValidDigits = false;
                        }
                    }
                }

                if (count == 2)
                {
                    break;
                }
            }

            return isValidDigits;
        }

        public static bool LettersDigitsCheck(string pass)
        {
            bool isValidDigitsLetters = true;
            char[] digitsLetters = { ')', '(', '^', '%', '$', '#', '@', '!', '*', '&', '\\', '/', ':', ';',
                '.', ',', '?', '=', '-', '_', '+', '{', '}', '[', ']' };

            for (int i = 0; i < pass.Length; i++)
            {
                for (int b = 0; b < digitsLetters.Length; b++)
                {
                    if (pass[i] == digitsLetters[b])
                    {
                        isValidDigitsLetters = false;
                        break;
                    }
                    else
                    {
                        isValidDigitsLetters = true;
                    }
                }
                if (isValidDigitsLetters == false)
                {
                    break;
                }
            }

            return isValidDigitsLetters;
        }
    }
}
