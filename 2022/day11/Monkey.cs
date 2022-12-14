namespace Day11;
internal class Monkey
{
    internal int Position { get; init; }

    internal List<ulong> Items { get; init; }

    internal Func<ulong, ulong> Operation { get; init; }

    internal ulong TestDivisible { get; init; }

    internal int ThrowToMonkeyIfTrue { get; init; }

    internal int ThrowToMonkeyIfFalse { get; init; }

    internal int InspectedItemsCount { get; set; }
}
