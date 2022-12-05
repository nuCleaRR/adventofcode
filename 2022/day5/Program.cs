using Day5;
using System.Collections.Generic;
using System.Text.RegularExpressions;

var inputFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "input.txt"));
var input = inputFile.Split(Environment.NewLine);

// task 1
var cargoInput = input.Take(..8).ToList();
var cargoStacksTask1 = GetCargoStacks(cargoInput);

List<Stack<char>> GetCargoStacks(List<string> cargoInput)
{
    var cargoStacks = new List<Stack<char>>();

    for (int i = cargoInput.Count - 1; i >= 0; i--)
    {
        var row = cargoInput[i];
        var cargoRow = Regex.Matches(row, @"\w");

        for (int j = 0; j < cargoRow.Count; j++)
        {
            var currentStack = cargoStacks.ElementAtOrDefault(j);
            if (currentStack == null)
            {
                currentStack = new Stack<char>();
                cargoStacks.Add(currentStack);
            }

            var value = cargoRow.ElementAt(j).Value[0];

            if (value != 'x')
            {
                currentStack.Push(value);
            }
        }
    }

    return cargoStacks;
}



var moveList = input.Take(10..).ToList();
var moveStrategies = new List<MoveStrategy>();

foreach (var move in moveList)
{
    var moveRegex = Regex.Matches(move, @"\d+");

    moveStrategies.Add(new MoveStrategy()
    {
        Count = Int32.Parse(moveRegex.ElementAt(0).Value),
        From = Int32.Parse(moveRegex.ElementAt(1).Value) - 1,
        To = Int32.Parse(moveRegex.ElementAt(2).Value) - 1,
    });
}

// make sorting
foreach (var moveStrategy in moveStrategies)
{
    var fromStack = cargoStacksTask1[moveStrategy.From];
    var toStack = cargoStacksTask1[moveStrategy.To];

    for (int i = 0; i < moveStrategy.Count; i++)
    {
        toStack.Push(fromStack.Pop());
    }
}

var task1ResultList = new List<char>();
cargoStacksTask1.ForEach(stack => task1ResultList.Add(stack.Peek()));

var task1Result = String.Join("", task1ResultList);
Console.WriteLine($"Task 1 result {task1Result}");// TGWSMRBPN

// task 2
// well, Stack is not good choice for task 2, but I'm lazy to rewrite the code :)
var cargoStacksTask2 = GetCargoStacks(cargoInput);
foreach (var moveStrategy in moveStrategies)
{
    var fromStack = cargoStacksTask2[moveStrategy.From];
    var toStack = cargoStacksTask2[moveStrategy.To];

    var cratesToPush = new List<char>();

    for (int i = 0; i < moveStrategy.Count; i++)
    {
        cratesToPush.Add(fromStack.Pop());
    }

    cratesToPush.Reverse();
    cratesToPush.ForEach(toStack.Push);
}

var task2ResultList = new List<char>();
cargoStacksTask2.ForEach(stack => task2ResultList.Add(stack.Peek()));
var task2Result = String.Join("", task2ResultList);
Console.WriteLine($"Task 1 result {task2Result}");// TZLTLWRNF