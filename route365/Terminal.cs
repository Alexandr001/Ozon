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
        Writer writer = new();
        foreach (var c in str)
        {
            switch (c)
            {
                case 'L':
                    writer.GoLeft();
                    break;
                case 'R':
                    writer.GoRight();
                    break;
                case 'U':
                    writer.GoUp();
                    break;
                case 'D':
                    writer.GoDown();
                    break;
                case 'B':
                    writer.GoBegin();
                    break;
                case 'E':
                    writer.GoEnd();
                    break;
                case 'N':
                    writer.NewLine();
                    break;
                default:
                    writer.Write(c);
                    break;
            }
        }

        return string.Join('\n', writer.Result);
    }

    struct Writer
    {
        private List<int> _maxX = new(){0};
        private int _maxY = 0;

        private int _x = 0;
        private int _y = 0;

        public Writer()
        {
        }

        public List<string> Result { get; } = new() { "" };

        public void GoLeft()
        {
            if (_x > 0)
            {
                _x--;
            }
        }

        public void GoRight()
        {
            if (_x < _maxX[_y])
            {
                _x++;
            }
        }

        public void GoUp()
        {
            if (_y > 0)
            {
                _y--;
            }

            if (_x > _maxX[_y])
            {
                _x = _maxX[_y];
            }
        }

        public void GoDown()
        {
            if (_y < _maxY)
            {
                _y++;
            }
            if (_x > _maxX[_y])
            {
                _x = _maxX[_y];
            }
        }

        public void GoBegin()
        {
            _x = 0;
        }

        public void GoEnd()
        {
            _x = _maxX[_y];
        }

        public void NewLine()
        {
            Result.Insert(_y + 1, Result[_y][_x..]);
            _maxX.Insert(_y + 1, Result[_y][_x..].Length);
            
            Result[_y] = Result[_y][.._x];
            _maxX[_y] = Result[_y].Length;
            _y++;
            
            _maxX[_y] = Result[_y].Length;
            _maxY++;
            _x = 0;
        }

        public void Write(char c)
        {
            if (_x == _maxX[_y])
            {
                Result[_y] += c;
            }
            else
            {
                Result[_y] = Result[_y].Insert(_x, c.ToString());
            }
            _maxX[_y]++;
            _x++;
        }
    }
}