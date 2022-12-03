using Microsoft.VisualBasic;
using System;

var inputFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "input.txt"));
var rucksackArray = inputFile.Split(Environment.NewLine);


// task 1
var task1Result = 0;

foreach (var ruvcksack in rucksackArray)
{
    var middleIndex = ruvcksack.Length/2;
    var leftRucksack = ruvcksack.Substring(0, middleIndex);
    var rightRucksack = ruvcksack.Substring(middleIndex, middleIndex);

    var intersection = leftRucksack
        .Intersect(rightRucksack)
        .ToList();

    task1Result += CalculatePriority(intersection);
}

Console.WriteLine($"Task 1 result {task1Result}");// 7848

// task 2
var task2Result = 0;

for (int i = 0; i < rucksackArray.Length; i+=3)
{
    var firstRucksack = rucksackArray[i];
    var secondRucksack = rucksackArray[i + 1];

    var intersection = firstRucksack.Intersect(secondRucksack);

    var thirdRucksack = rucksackArray[i + 2];
    intersection = intersection.Intersect(thirdRucksack);

    task2Result += CalculatePriority(intersection.ToList());
}

Console.WriteLine($"Task 2 result {task2Result}");// 2616

int CalculatePriority(List<char> items)
{
    const int unicodeLowerOffset = 96;
    const int unicodeUpperOffset = 38;

    var result = 0;

    foreach (var item in items)
    {
        if (char.IsUpper(item))
        {
            result += item - unicodeUpperOffset;
        }
        else
        {
            result += item - unicodeLowerOffset;
        }
    }

    return result;
}