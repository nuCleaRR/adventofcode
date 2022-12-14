namespace Day11;
internal class Input
{
    public static List<Monkey> GetTest() =>
        new()
        {
            new Monkey
            {
                Position = 0,
                Items = new List<ulong>{ 79, 98 },
                Operation = x => x * 19,
                TestDivisible = 23,
                ThrowToMonkeyIfTrue = 2,
                ThrowToMonkeyIfFalse = 3
            },
            new Monkey
            {
                Position = 1,
                Items = new List<ulong>{ 54, 65, 75, 74 },
                Operation = x => x + 6,
                TestDivisible = 19,
                ThrowToMonkeyIfTrue = 2,
                ThrowToMonkeyIfFalse = 0
            },
            new Monkey
            {
                Position = 2,
                Items = new List<ulong>{ 79, 60, 97 },
                Operation = x => x * x,
                TestDivisible = 13,
                ThrowToMonkeyIfTrue = 1,
                ThrowToMonkeyIfFalse = 3
            },
            new Monkey
            {
                Position = 3,
                Items = new List<ulong>{ 74 },
                Operation = x => x + 3,
                TestDivisible = 17,
                ThrowToMonkeyIfTrue = 0,
                ThrowToMonkeyIfFalse = 1
            },
        };

    public static List<Monkey> Get() =>
        new()
        {
            new Monkey
            {
                Position = 0,
                Items = new List<ulong>{ 72, 97 },
                Operation = x => x * 13,
                TestDivisible = 19,
                ThrowToMonkeyIfTrue = 5,
                ThrowToMonkeyIfFalse = 6
            },
            new Monkey
            {
                Position = 1,
                Items = new List<ulong>{ 55, 70, 90, 74, 95 },
                Operation = x => x * x,
                TestDivisible = 7,
                ThrowToMonkeyIfTrue = 5,
                ThrowToMonkeyIfFalse = 0
            },
            new Monkey
            {
                Position = 2,
                Items = new List<ulong>{ 74, 97, 66, 57 },
                Operation = x => x + 6,
                TestDivisible = 17,
                ThrowToMonkeyIfTrue = 1,
                ThrowToMonkeyIfFalse = 0
            },
            new Monkey
            {
                Position = 3,
                Items = new List<ulong>{ 86, 54, 53 },
                Operation = x => x + 2,
                TestDivisible = 13,
                ThrowToMonkeyIfTrue = 1,
                ThrowToMonkeyIfFalse = 2
            },
            new Monkey
            {
                Position = 4,
                Items = new List<ulong>{ 50, 65, 78, 50, 62, 99 },
                Operation = x => x + 3,
                TestDivisible = 11,
                ThrowToMonkeyIfTrue = 3,
                ThrowToMonkeyIfFalse = 7
            },
            new Monkey
            {
                Position = 5,
                Items = new List<ulong>{ 90 },
                Operation = x => x + 4,
                TestDivisible = 2,
                ThrowToMonkeyIfTrue = 4,
                ThrowToMonkeyIfFalse = 6
            },
            new Monkey
            {
                Position = 6,
                Items = new List<ulong>{ 88, 92, 63, 94, 96, 82, 53, 53 },
                Operation = x => x + 8,
                TestDivisible = 5,
                ThrowToMonkeyIfTrue = 4,
                ThrowToMonkeyIfFalse = 7
            },
            new Monkey
            {
                Position = 7,
                Items = new List<ulong>{ 70, 60, 71, 69, 77, 70, 98 },
                Operation = x => x * 7,
                TestDivisible = 3,
                ThrowToMonkeyIfTrue = 2,
                ThrowToMonkeyIfFalse = 3
            },
        };
}
