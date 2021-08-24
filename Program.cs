using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	private static Random random = new Random();
    private static int CHARS_OF_THE_MATRIX = 4096;
	public static void Main()
    {
        // Instanciate random input matrix and words to find
        string[] matrix = CreateRandomInputMatrix();
        string[] stream = WordsToFind();

        // Main logic
        WordFinder finder = new WordFinder(matrix);
        IEnumerable<string> result = finder.Find(stream);
        
        PrintResult(result);
        Console.ReadLine();
    }
	private static string[] WordsToFind()
    {
        return new string[15] { "CHO", "OSE", "THE", "WOR", "DS", "YOU", "WAN", "T", "TO", "FIND", "FOR", "TESTING", "PUR", "POSES", "THANKS" };
	}
    private static string[] CreateRandomInputMatrix()
    {
        string[] randomMatrix = new string[CHARS_OF_THE_MATRIX];
        for (int i = 0; i < CHARS_OF_THE_MATRIX; i++)
        {
            randomMatrix[i] = RandomString(1);
        }

        return randomMatrix;
    }
    private static void PrintResult(IEnumerable<string> result)
    {
        foreach (string s in result)
        {
            Console.WriteLine(s);
        }
    }
    public static string RandomString(int length)
	{
		const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		return new string(Enumerable.Repeat(chars, length)
		  .Select(s => s[random.Next(s.Length)]).ToArray());
	}
}




