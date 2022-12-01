var inputFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "input.txt"));
var inputArray = inputFile.Split(Environment.NewLine);

var maxCaloriesElf = 0;
var currentElfCallories = 0;

var caloriesPerElf = new List<int>();

foreach (var item in inputArray)
{
    if (string.IsNullOrEmpty(item))
    {
        caloriesPerElf.Add(currentElfCallories);

        if (currentElfCallories > maxCaloriesElf)
        {
            maxCaloriesElf = currentElfCallories;
        }

        currentElfCallories = 0;
        continue;
    }

    currentElfCallories += int.Parse(item);
}

Console.WriteLine($"Task 1 result is {maxCaloriesElf}");

caloriesPerElf.Sort();
var fattyElves = caloriesPerElf
    .Take(^3..)
    .Sum();

Console.WriteLine($"Task 2 result is {fattyElves}");