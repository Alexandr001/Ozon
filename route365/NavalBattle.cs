namespace route365;

/// <summary>
///     Задача "Проверка даты"
/// </summary>
public static class NavalBattle
{
    public static void Main()
    {
        var numberOfSet = int.Parse(Console.ReadLine()!);
        var results = new string[numberOfSet];
        for (var i = 0; i < numberOfSet; i++)
        {
            var array = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            results[i] = Execute(array) ? "YES" : "NO";
        }

        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }

    static bool Execute(int[] arr)
    {
        var a = 1;
        var b = 2;
        var c = 3;
        var d = 4;
        foreach (var i in arr)
        {
            switch (i)
            {
                case 4: a--;
                    break;
                case 3: b--;
                    break;
                case 2: c--;
                    break;
                case 1: d--;
                    break;
            }
        }

        return a == 0 && b == 0 && c == 0 && d == 0;
    }
}