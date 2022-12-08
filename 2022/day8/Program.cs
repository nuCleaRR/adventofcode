var inputFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "input.txt"));
var input = inputFile.Split(Environment.NewLine).ToList();

var treeList = new List<List<int>>();

foreach (var item in input)
{
    var tree = item.Select(x => (int)char.GetNumericValue(x)).ToList();
    treeList.Add(tree);
}

// task 1
//                               coordinates, height
var visibleTrees = new Dictionary<(int, int), int>();

// from left to right
// from right to left
for (int i = 1; i < treeList.Count - 1; i++) // omit perimeter lines
{
    var line = treeList[i];

    CalculateTreeVisibility(line, i, false);
    CalculateTreeVisibilityReverse(line, i, false);
}

// from top to bottom
// from bottom to top
for(int i = 1; i < treeList.Count - 1; i++) // omit perimeter lines
{
    var verticalLine = new List<int>();
    for (int j = 0; j < treeList.Count; j++)
    {
        verticalLine.Add(treeList[j][i]);
    }

    CalculateTreeVisibility(verticalLine, i, true);
    CalculateTreeVisibilityReverse(verticalLine, i, true);
}

// add perimeter trees
var perimeterTrees = treeList.Count * 4 - 4;
var task1Result = visibleTrees.Count + perimeterTrees;
Console.WriteLine($"Task 1 result {task1Result}"); // 1818

void CalculateTreeVisibility(List<int> treeLine, int i, bool isVerticalLine)
{
    var previousTree = treeLine.First();

    for (int j = 1; j < treeLine.Count - 1; j++)
    {
        var currentTree = treeLine[j];

        if (currentTree <= previousTree)
        {
            continue;
        }

        if (isVerticalLine)
        {
            TryAddTreeToVisible((j, i), currentTree);
        }
        else
        {
            TryAddTreeToVisible((i, j), currentTree);
        }

        previousTree = currentTree;
    }
}

void CalculateTreeVisibilityReverse(List<int> treeLine, int i, bool reversePoint = false)
{
    var previousTree = treeLine.Last();

    for (int j = treeLine.Count - 2; j > 0; j--)
    {
        var currentTree = treeLine[j];

        if (currentTree <= previousTree)
            continue;

        if (reversePoint)
        {
            TryAddTreeToVisible((j, i), currentTree);
        }
        else
        {
            TryAddTreeToVisible((i, j), currentTree);
        }

        previousTree = currentTree;
    }
}
void TryAddTreeToVisible((int, int) point, int height)
{
    if (!visibleTrees.ContainsKey(point))
    {
        visibleTrees.Add(point, height);
    }
}

// task 2
var task2Result = 0;

for (int i = 1; i < treeList.Count - 1; i++) // omit perimeter lines
{
    var line = treeList[i];

    for (int j = 1; j < line.Count - 1; j++)
    {
        var iterationMax = 1;
        var currentScore = 0;
        var item = line[j];

        // from item to left
        for (int x = j - 1; x >= 0; x--)
        {
            var compareTo = line[x];
            currentScore++;

            if (compareTo >= item)
            {
                break;
            }
        }

        if (currentScore != 0)
        {
            iterationMax = iterationMax * currentScore;
        }
        
        currentScore = 0;

        // from item to right
        for (int x = j + 1; x < line.Count; x++)
        {
            var compareTo = line[x];

            currentScore++;

            if (compareTo >= item)
            {
                break;
            }
        }

        if (currentScore != 0)
        {
            iterationMax = iterationMax * currentScore;
        }

        currentScore = 0;

        // from item to bottom
        for (int x = i + 1; x < line.Count; x++)
        {
            var compareTo = treeList[x][j];

            currentScore++;

            if (compareTo >= item)
            {
                break;
            }
        }

        if (currentScore != 0)
        {
            iterationMax = iterationMax * currentScore;
        }

        currentScore = 0;

        // from item to top
        for (int x = i - 1; x >=0; x--)
        {
            var compareTo = treeList[x][j];

            currentScore++;

            if (compareTo >= item)
            {
                break;
            }
        }

        if (currentScore != 0)
        {
            iterationMax = iterationMax * currentScore;
        }

        currentScore = 0;

        task2Result = Math.Max(task2Result, iterationMax);
    }
}

Console.WriteLine($"Task 2 result {task2Result}"); // 368368