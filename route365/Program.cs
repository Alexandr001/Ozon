Console.WriteLine("hello world");


var numberOfSet = int.Parse(Console.ReadLine()!);
var arrayResults = new int[numberOfSet][];
for (var i = 0; i < numberOfSet; i++)
{
    var dataCount = int.Parse(Console.ReadLine()!);
    arrayResults[i] = new int[dataCount];
    var temps = new TemperatureRegulator[dataCount];
    for (var j = 0; j < dataCount; j++)
    {
        var array = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
        temps[j] = new TemperatureRegulator(int.Parse(array[1]), array[0]);
    }

    arrayResults[i] = Execute(temps, arrayResults[i]);
}

foreach (var result in arrayResults)
{
    foreach (var i in result)
    {
        Console.WriteLine(i);
    }

    Console.WriteLine();
}

static int[] Execute(TemperatureRegulator[] temps, int[] results)
{
    const int MIN_TEMP = 15;
    const int MAX_TEMP = 30;

    var currentTemp = temps[0].Temp;
    var maxCurrentTemp = MAX_TEMP;
    var minCurrentTemp = MIN_TEMP;

    if (temps[0].Action == ">=")
    {
        results[0] = currentTemp;
        minCurrentTemp = currentTemp;
    }
    else
    {
        results[0] = minCurrentTemp;
        maxCurrentTemp = currentTemp;
    }

    var isError = false;
    for (var i = 1; i < temps.Length; i++)
    {
        TemperatureRegulator obj = temps[i];

        if (isError)
        {
            results[i] = -1;
            continue;
        }

        if (obj.Action == "<=" && obj.Temp >= minCurrentTemp && obj.Temp <= maxCurrentTemp)
        {
            maxCurrentTemp = obj.Temp;
            results[i] = minCurrentTemp;
        }
        else if (obj.Action == ">=" && obj.Temp <= maxCurrentTemp && obj.Temp >= minCurrentTemp)
        {
            currentTemp = obj.Temp;
            minCurrentTemp = obj.Temp;
            results[i] = currentTemp;
        }
        else if (obj.Action == "<=" && obj.Temp > maxCurrentTemp || obj.Action == ">=" && obj.Temp < minCurrentTemp)
        {
            results[i] = minCurrentTemp;
        }
        else
        {
            results[i] = -1;
            isError = true;
        }
    }

    return results;
}

struct TemperatureRegulator
{
    public TemperatureRegulator(int temp, string action)
    {
        Temp = temp;
        Action = action;
    }

    public int Temp { get; }
    public string Action { get; }
}