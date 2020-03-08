using System;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine().Split();

        var tuple1 = new _07_Tuple.Tuple<string, string>(input[0] + " " + input[1], input[2]);

        Console.WriteLine(tuple1);

        input = Console.ReadLine().Split();

        var tuple2 = new _07_Tuple.Tuple<string, int>(input[0], int.Parse(input[1]));

        Console.WriteLine(tuple2);

        input = Console.ReadLine().Split();

        var tuple3 = new _07_Tuple.Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));

        Console.WriteLine(tuple3);
    }
}