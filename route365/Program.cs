Console.WriteLine("hello world");


var numberOfSet = int.Parse(Console.ReadLine()!);
var arrayResults = new int[numberOfSet][];
for (var i = 0; i < numberOfSet; i++)
{
    _ = int.Parse(Console.ReadLine()!);
    var array = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    arrayResults[i] = Execute(array);
}

foreach (var result in arrayResults)
{
    Console.WriteLine(result.Length);
    Console.WriteLine(string.Join(' ', result));
}


static int[] Execute(int[] arr)
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
            if (arr.ElementAtOrDefault(j - 1) - arr.ElementAtOrDefault(j) == -1 && isIncrease == true)
            {
                continue;
            }

            if (arr.ElementAtOrDefault(j - 1) - arr.ElementAtOrDefault(j) == 1 && isIncrease == false)
            {
                continue;
            }

            results.Add(arr[j - 1] - arr[i]);
            i = j - 1;
            break;
        }
    }

    return results.ToArray();
}