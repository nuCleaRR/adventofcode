var inputFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "input.txt"));
var input = inputFile.Split(Environment.NewLine);

// task 1
var task1Result = 0;

for (int i = 0;i < input.Length; i++)
{
    var assignment = input[i].Split(',');
    var firstElfAssignment = assignment[0].Split('-');
    var secondElfAssignment = assignment[1].Split('-');

    var firstStartIndex = Int32.Parse(firstElfAssignment[0]);
    var firstCount = Int32.Parse(firstElfAssignment[1]) - firstStartIndex + 1;
    var firstArray = Enumerable.Range(firstStartIndex, firstCount).ToList();

    var secondStartIndex = Int32.Parse(secondElfAssignment[0]);
    var secondCount = Int32.Parse(secondElfAssignment[1]) - secondStartIndex + 1;
    var secondArray = Enumerable.Range(secondStartIndex, secondCount).ToList();

    var unionArray = firstArray.Union(secondArray).ToList();
    var unionArrayReverse = secondArray.Union(firstArray).ToList();

    if (unionArray.Count == firstArray.Count || unionArrayReverse.Count == secondArray.Count)
    {
        task1Result++;
    }
}

Console.WriteLine($"Task 1 result {task1Result}");// 496

// task 2
// go dirty
var task2Result = 0;

var task2Input = new List<(List<int>, List<int>)>(input.Length);

for (int i = 0; i < input.Length; i = i + 1)
{
    var current = input[i].Split(',');
    var item1 = Tuple.Create(Int32.Parse(current[0].Split('-')[0]), Int32.Parse(current[0].Split('-')[1]));
    var item2 = Tuple.Create(Int32.Parse(current[1].Split('-')[0]), Int32.Parse(current[1].Split('-')[1]));

    var array1 = Enumerable.Range(item1.Item1, item1.Item2 - item1.Item1 + 1).ToList();
    var array2 = Enumerable.Range(item2.Item1, item2.Item2 - item2.Item1 + 1).ToList();

    task2Input.Add((array1, array2));
}

for (int i = 0; i < task2Input.Count; i++)
{
    var item1 = task2Input[i].Item1;
    var item2 = task2Input[i].Item2;

    var union = item1.Union(item2);

    if (union.Count() != item1.Count + item2.Count)
    {
        task2Result++;
    }
}

Console.WriteLine($"Task 2 result {task2Result}");// 847