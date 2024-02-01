namespace route365;

public class DocumentPrinting
{
    public static void Main()
    {
        var numberOfSet = int.Parse(Console.ReadLine()!);
        var results = new List<string>(numberOfSet);
        for (var i = 0; i < numberOfSet; i++)
        {
            var countPage = int.Parse(Console.ReadLine()!);
            var str = Console.ReadLine()!;

            results.Add(Execute(str, countPage));
        }

        Console.WriteLine(string.Join('\n', results));
    }

    static string Execute(string str, int countPage)
    {
        str += ',';
        var result = new List<string>();
        var printedPages = NewMethod(str);

        var value = 0;
        string? buf = null;
        for (var i = 1; i <= countPage; i++)
        {
            if (printedPages.Contains(i))
            {
                if (buf is not null)
                {
                    if (buf != value.ToString())
                    {
                        buf += '-' + value.ToString();
                    }
                    result.Add(buf);
                    buf = null;
                }
                continue;
            }

            if (i == countPage)
            {
                if (buf is null)
                {
                    buf = i.ToString();
                }
                else
                {
                    buf += '-' + i.ToString();
                }
                result.Add(buf);
            }

            if (i - value == 1 || value == 0)
            {
                buf ??= i.ToString();

                value = i;
                continue;
            }
            value = i;
            buf = i.ToString();
        }
        
        return string.Join(',', result);
    }

    static List<int> NewMethod(string str)
    {
        var list = new List<int>();
        var buf = "";
        var flag = false;
        
        foreach (var c in str)
        {
            if (char.IsNumber(c))
            {
                buf += c;
                continue;
            }

            list.Add(int.Parse(buf));
            buf = "";

            if (c == ',')
            {
                if (flag)
                {
                    var maxVal = list[^1];
                    var minVal = list[^2];
                    for (var j = minVal + 1; j < maxVal; j++)
                    {
                        list.Insert(list.Count - 1, j);
                    }
                }

                flag = false;
            }

            if (c == '-')
            {
                flag = true;
            }
        }
        return list;
    }
}

/*
 Если "-" то берем два числа вокруг и заполняем по очереди уже готовые странички
 Если число, то смотрим следующий символ, если запятая то добавляем этот символ в результат, если тире то смотрим ещё симол и добавляем список в результат
 */