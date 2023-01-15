var inputFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "input.txt"));
var input = inputFile.Split(Environment.NewLine).ToList();

var forrestHeight = input.Count;
int forrestWidth = input.First().Length;
var forrestMap = new int[forrestHeight, forrestWidth];

Point startPoint = null;
Point endPoint = null;

for (int y = 0; y < forrestHeight; y++)
{
    var line = input[y];
    for (int x = 0; x < forrestWidth; x++)
	{
		var letter = line[x];

		if (letter == 'S')
		{
            letter = 'a';
            startPoint = new Point() { X = x, Y = y };
        }

        if (letter == 'E')
        {
            letter = 'z';
            endPoint = new Point() { X = x, Y = y };
        }

        forrestMap[y, x] = letter - 97;
	}
}

// task 1
var task1Start = new List<Point>() { startPoint };
var task1Result = GetShortestPathByBfs(task1Start);
Console.WriteLine($"Task 1 result {task1Result}");// 456

var task2Start = new List<Point>();

for (int y = 0; y < forrestHeight; y++)
{
    for (int x = 0; x < forrestWidth; x++)
    {
        if (forrestMap[y,x] == 0) // letter 'a'
        {
            task2Start.Add(new Point() { X = x, Y = y });
        }
    }
}

var task2Result = GetShortestPathByBfs(task2Start);
Console.WriteLine($"Task 2 result {task2Result}");// 454

// Breadth-first search algorithm - BFS
int GetShortestPathByBfs(List<Point> startSearchPoints)
{
    var boundaryPoints = new List<Point> {
        new Point() {X = -1, Y = 0 },
        new Point() {X = 0, Y = -1 },
        new Point() {X = 1, Y = 0 },
        new Point() {X = 0, Y = 1 },
    };

    var queue = new Queue<(Point, int step)>();
    startSearchPoints.ForEach(p => queue.Enqueue((p, 0)));

    var visited = new HashSet<Point>();

    while (queue.Any())
    {
        (Point currentPoint, int step) = queue.Dequeue();

        if (visited.Add(currentPoint) == false)
        {
            continue;
        }

        if (currentPoint == endPoint)
        {
            return step;
        }

        foreach (var point in boundaryPoints)
        {
            var destinationX = currentPoint.X + point.X;
            var destinationY = currentPoint.Y + point.Y;

            if (destinationX < 0 || destinationY < 0 ||
                destinationX >= forrestWidth|| destinationY >= forrestHeight)
                continue;

            var destinationHeight = forrestMap[destinationY, destinationX];
            var currentHeight = forrestMap[currentPoint.Y, currentPoint.X];

            // the elevation of the destination square can be at most one higher than the elevation of your current square
            if (destinationHeight - currentHeight <= 1)
            {
                var destinationPoint = new Point { X = destinationX, Y = destinationY };
                queue.Enqueue((destinationPoint, step + 1));
            }
        }
    }

    return 0;
}