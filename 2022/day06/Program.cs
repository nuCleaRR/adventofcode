var inputFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "input.txt"));

// task 1
var task1Result = FindOffset(inputFile, 4);
Console.WriteLine($"Task 1 result {task1Result}");// 1262

// task 2
var task2Result = FindOffset(inputFile, 14);
Console.WriteLine($"Task 1 result {task2Result}");// 3444


int FindOffset(string input, int offsetStep)
{
    var offset = offsetStep;
    var result = 0;
    do
    {
        var stringUnderTest = input[(offset - offsetStep)..offset];
        var disctinctString = stringUnderTest.Distinct().ToList();

        if (disctinctString.Count == stringUnderTest.Length)
        {
            result = offset;
            break;
        }

        offset++;

    }
    while (offset < input.Length);

    return result;
}