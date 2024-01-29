﻿namespace route365;

class DataCompression
{
    public static void Main()
    {
        var numberOfSet = int.Parse(Console.ReadLine()!);
        var arrayResults = new List<List<int>>(numberOfSet);
        for (var i = 0; i < numberOfSet; i++)
        {
            _ = int.Parse(Console.ReadLine()!);
            var array = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            arrayResults.Add(Execute(array));
        }

        foreach (var result in arrayResults)
        {
            Console.WriteLine(result.Count);
            Console.WriteLine(string.Join(' ', result));
        }
    }

    static List<int> Execute(int[] arr)
    {
        var results = new List<int>();
        for (var i = 0; i < arr.Length; i++)
        {
            bool? isIncrease = null;
            results.Add(arr[i]);

            if (arr.ElementAtOrDefault(i) - arr.ElementAtOrDefault(i + 1) == 1)
            {
                isIncrease = false;
            }
            else if (arr.ElementAtOrDefault(i) - arr.ElementAtOrDefault(i + 1) == -1)
            {
                isIncrease = true;
            }
            else
            {
                results.Add(0);
                continue;
            }
            
            for (var j = i + 1; j <= arr.Length; j++)
            {
                if (j != arr.Length && arr[j - 1] - arr[j] == -1 && isIncrease == true)
                {
                    continue;
                }
                if (j != arr.Length && arr[j - 1] - arr[j] == 1 && isIncrease == false)
                {
                    continue;
                }
                
                results.Add(arr[j - 1] - arr[i]);
                i = j - 1;
                break;
            }
        }
        return results;
    }
}