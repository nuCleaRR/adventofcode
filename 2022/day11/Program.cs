using Day11;

var monkeysTask1 = Input.Get();
var task1Result = PlayKeepAway(20, 3, monkeysTask1);
Console.WriteLine($"Task 1 result {task1Result}");// 58056

var monkeysTask2 = Input.Get();
var task2Result = PlayKeepAway(10000, 1, monkeysTask2);
Console.WriteLine($"Task 2 result {task2Result}");// 15048718170

long PlayKeepAway(int maxRound, ulong relief, List<Monkey> monkeys)
{
    var module = monkeys
        .Select(x => x.TestDivisible)
        .Aggregate((a, x) => a * x);

    for (int i = 1; i <= maxRound; i++)
    {
        foreach (var monkey in monkeys)
        {
            foreach (var item in monkey.Items)
            {
                var worryLevel = monkey.Operation(item) / relief;

                worryLevel = worryLevel % module; // compress worry level by module

                var nextMonkey = worryLevel % monkey.TestDivisible == 0 ? monkey.ThrowToMonkeyIfTrue : monkey.ThrowToMonkeyIfFalse;

                monkeys[nextMonkey].Items.Add(worryLevel);

                monkey.InspectedItemsCount++;
            }

            monkey.Items.Clear();
        }
    }

    var mostActiveMonkeys = monkeys
    .Select(x => x.InspectedItemsCount)
    .Order()
    .TakeLast(2);

    var result = Math.BigMul(mostActiveMonkeys.First(), mostActiveMonkeys.Last());

    return result;
}