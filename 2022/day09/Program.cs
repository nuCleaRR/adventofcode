using Day9;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

var inputFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "input.txt"));
var input = inputFile.Split(Environment.NewLine).ToList();

var moveStrategyList = new List<MoveStrategy>(input.Select(MoveStrategy.GetStrategy));

var task1Result = CountLastKnotUniquePositions(2, moveStrategyList);
Console.WriteLine($"Task 1 result {task1Result}");// 5735

var task2Result = CountLastKnotUniquePositions(10, moveStrategyList);
Console.WriteLine($"Task 2 result {task2Result}");// //2478

int CountLastKnotUniquePositions(int knots, List<MoveStrategy> moveStrategyList)
{
    var tailMoveHistory = new HashSet<(int x, int y)>();
    (int x, int y)[] rope = new (int x, int y)[knots - 1];
    (int x, int y) head = new(0, 0);

    foreach (var strategy in moveStrategyList)
    {
        var offset = strategy.GetOffset();

        for (int i = 0; i < strategy.Steps; i++)
        {
            head.x += offset.x;
            head.y += offset.y;

            // play with knots
            for (int j = 0; j < rope.Length; j++)
            {
                var currentKnot = rope[j];
                var previousKnot = j == 0 ? head : rope[j-1];
                (int x, int y) delta = (previousKnot.x - currentKnot.x, previousKnot.y - currentKnot.y);
                if (Math.Abs(delta.x) > 1 || Math.Abs(delta.y) > 1)
                {
                    (int x, int y) offsetKnot = (currentKnot.x + Math.Sign(delta.x), currentKnot.y + Math.Sign(delta.y));
                    rope[j] = offsetKnot;
                }
            }

            tailMoveHistory.Add(rope[^1]);
        }
    }
    return tailMoveHistory.Count;
}