using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        const string filePath = @"C:\Users\админ\OneDrive\Документы\30000 strings.txt";
        const string userFile = @"C:\Users\админ\OneDrive\Документы\user_data.txt";


        
        var lines = await ReadFileAsync(filePath);

        
        Console.WriteLine("Write Name:");
        var firstName = Console.ReadLine();

        Console.WriteLine("Write Surname:");
        var lastName = Console.ReadLine();

        
        Console.WriteLine("Print data? (y/n)");
        var printData = Console.ReadLine().ToLower() == "y";

        if (printData)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            File.WriteAllText(userFile, $"{firstName} {lastName}");
            Console.WriteLine("User data saved to: {0}", userFile);
        }
    }

    static async Task<string[]> ReadFileAsync(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            var lines = new List<string>();
            while (!reader.EndOfStream)
            {
                lines.Add(await reader.ReadLineAsync());
            }
            return lines.ToArray();
        }
    }
}
