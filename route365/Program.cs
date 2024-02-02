List<string> _test = new()
{
    "2S",
    "2C",
    "2D",
    "2H",
    "3S",
    "3C",
    "3D",
    "3H",
    "4S",
    "4C",
    "4D",
    "4H",
    "5S",
    "5C",
    "5D",
    "5H",
    "6S",
    "6C",
    "6D",
    "6H",
    "7S",
    "7C",
    "7D",
    "7H",
    "8S",
    "8C",
    "8D",
    "8H",
    "9S",
    "9C",
    "9D",
    "9H",
    "TS",
    "TC",
    "TD",
    "TH",
    "JS",
    "JC",
    "JD",
    "JH",
    "QS",
    "QC",
    "QD",
    "QH",
    "KS",
    "KC",
    "KD",
    "KH",
    "AS",
    "AC",
    "AD",
    "AH"
};

List<Card> _allCards = null!;


var allCards = new List<Card>(_test.Count);
allCards.AddRange(_test.Select(Card.Parse));
_allCards = allCards;

var numberOfSet = int.Parse(Console.ReadLine()!);

var fullResult = new List<string[]>(numberOfSet);
for (var i = 0; i < numberOfSet; i++)
{
    var playerCount = int.Parse(Console.ReadLine()!);
    var sets = new List<Card[]>(playerCount);
    for (var j = 0; j < playerCount; j++)
    {
        var set = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(Card.Parse)
            .ToArray();
        sets.Add(set);
    }

    fullResult.Add(Execute(sets).Select(s => s.ToString()).ToArray());
}

foreach (var res in fullResult)
{
    Console.WriteLine(res.Length);
    foreach (var re in res)
    {
        Console.WriteLine(re);
    }
}

List<string> Execute(List<Card[]> sets)
{
    var myCards = sets[0];
    var availableCards = _allCards.Except(sets.SelectMany(s => s)).ToList();
    var results = new List<string>();
    foreach (Card card in availableCards)
    {
        var hasWrite = true;
        var myMax = GetSum(card.Number, myCards[0].Number, myCards[1].Number);
        for (var j = 1; j < sets.Count; j++)
        {
            var set = sets[j];
            if (myMax < GetSum(card.Number, set[0].Number, set[1].Number))
            {
                hasWrite = false;
                break;
            }
        }

        if (hasWrite)
        {
            results.Add(card.ToString());
        }
    }

    return results;
}

int GetSum(int a, int b, int c)
{
    if (a == b && a == c)
    {
        return a * 1000;
    }

    if (a == b || a == c || c == b)
    {
        if (a == b)
        {
            return a * 100;
        }

        if (a == c)
        {
            return a * 100;
        }

        if (c == b)
        {
            return c * 100;
        }
    }

    if (a > b && a > c)
    {
        return a;
    }
    
    if (b > a && b > c)
    {
        return b;
    }
    
    if (c > a && c > b)
    {
        return c;
    }

    throw new Exception();
}


struct Card
{
    public int Number { get; }

    public char Suit { get; }

    private Card(int number, char suit)
    {
        Number = number;
        Suit = suit;
    }

    public static Card Parse(string strCard)
    {
        var number = CharToInt(strCard[0]);
        return new Card(number, strCard[1]);
    }

    private static int CharToInt(char c)
    {
        return c switch
        {
            'T' => 10,
            'J' => 11,
            'Q' => 12,
            'K' => 13,
            'A' => 14,
            _ => int.Parse(c.ToString())
        };
    }

    private static char IntToChar(int c)
    {
        return c switch
        {
            10 => 'T',
            11 => 'J',
            12 => 'Q',
            13 => 'K',
            14 => 'A',
            _ => char.Parse(c.ToString())
        };
    }

    public override string ToString()
    {
        return $"{IntToChar(Number)}" + Suit;
    }
}