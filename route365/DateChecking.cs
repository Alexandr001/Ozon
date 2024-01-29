namespace route365;

/// <summary>
///     Задача "Проверка даты"
/// </summary>
public class DateChecking
{
    public static void Main()
    {
        var numberOfSet = int.Parse(Console.ReadLine()!);
        var results = new string[numberOfSet];
        for (var i = 0; i < numberOfSet; i++)
        {
            var array = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var date = new Date(array[0], array[1], array[2]);
            results[i] = Execute(date) ? "YES" : "NO";
        }

        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }

    static bool Execute(Date date)
    {
        var month31day = new int[] {1, 3, 5, 7, 8, 10 ,12};
        if (date.Day == 31 && month31day.Contains(date.Month) == false)
        {
            return false;
        }

        if (date is { Day: 29, Month: 2 } && IsLeapYear(date.Year))
        {
            return true;
        }

        return date is not { Day: > 28, Month: 2 };

        bool IsLeapYear(int year) => (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
    }

    struct Date
    {
        public int Day { get; }
        public int Month { get; }
        public int Year { get; }

        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
    }
}