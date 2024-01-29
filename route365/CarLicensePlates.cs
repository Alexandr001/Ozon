using System.Text;

namespace route365;

/// <summary>
///     Задача "автомодильные номера"
/// </summary>
public class CarLicensePlates
{
    public static void Main()
    {
        var numberOfSet = int.Parse(Console.ReadLine()!);
        var results = new string[numberOfSet];
        for (var i = 0; i < numberOfSet; i++)
        {
            var array = Console.ReadLine()!;
            results[i] = Execute(array) ?? "-";
        }

        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }

    static string? Execute(string str)
    {
        var builder = new StringBuilder();
        for (var i = 0; i < str.Length; i++)
        {
            var s = str[i..];
            if (char.IsLetter(s.ElementAtOrDefault(0)))
            {
                if (char.IsNumber(s.ElementAtOrDefault(1)))
                {
                    if (char.IsNumber(s.ElementAtOrDefault(2)))
                    {
                        if (char.IsLetter(s.ElementAtOrDefault(3)) && char.IsLetter(s.ElementAtOrDefault(4)))
                        {
                            builder.Append(s[..5] + ' ');
                            i += 4;
                            continue;
                        }
                    }
                    
                    if (char.IsLetter(s.ElementAtOrDefault(2)) && char.IsLetter(s.ElementAtOrDefault(3)))
                    {
                        builder.Append(s[..4] + ' ');
                        i += 3;
                        continue;
                    }
                }
            }

            return null;
        }

        return builder.ToString()[..^1];
    }
}