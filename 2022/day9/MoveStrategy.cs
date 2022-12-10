using System.Text.RegularExpressions;

namespace Day9;

internal class MoveStrategy
{
    private char _direction;

    internal int Steps { get; init; }

    internal (int x, int y) GetOffset()
    {
        var xOffset = _direction switch { 'R' => 1, 'L' => -1, _ => 0 };
        var yOffset = _direction switch { 'U' => 1, 'D' => -1, _ => 0 };

        return new (xOffset, yOffset);
    }

    public static MoveStrategy GetStrategy(string value)
    {
        var regexp = Regex.Matches(value, """(\D) (\d*)""");

        var direction = regexp[0].Groups[1].Value[0];

        var strategy = new MoveStrategy()
        {
            _direction = direction,
            Steps = int.Parse(regexp[0].Groups[2].Value)
        };

        return strategy;
    }
}