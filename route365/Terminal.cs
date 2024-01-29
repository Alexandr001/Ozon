namespace route365;

public class Terminal
{
    public static void Main()
    {
        var numberOfSet = int.Parse(Console.ReadLine()!);
        var arrayResults = new List<string>();
        for (var i = 0; i < numberOfSet; i++)
        {
            var str = Console.ReadLine()!;
            arrayResults.Add(Execute(str));
        }
        foreach (var result in arrayResults)
        {
            Console.WriteLine(result);
            Console.WriteLine('-');
        }
    }

    static string Execute(string str)
    {
        var result = new List<string> {};
        var j = 0;
        for (var i = 0; i < str.Length; i++)
        {
            var s = str[i];
            switch (s)
            {
                case 'L':
                    if (i != 0)
                    {
                        i--;
                    }
                    break;
                case 'R':
                    if (i != 0)
                    {
                        i++;
                    }
                    break;
                case 'U':
                    if (result.Count > 1)
                    {
                        i--;
                    }
                    break;
                case 'D':
                    if (result.Count > 1)
                    {
                        i++;
                    }
                    break;
                case 'B':
                    break;
                case 'E':
                    break;
                case 'N':
                    
                    break;
                default:
                    result.Add(s);
                    break;
            }
        }

        return "";
    }
}