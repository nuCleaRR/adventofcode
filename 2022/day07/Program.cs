using Day7;
using System.Text.RegularExpressions;

var inputFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "input.txt"));
var input = inputFile.Split(Environment.NewLine).Skip(2);

// task 1
var rootNode = new FolderNode { Value = "/" };
var currentNode = rootNode;

foreach (var line in input)
{
    if (line.StartsWith("$"))
    {
        // command
        var command = GetCommand(line);
        currentNode = command(currentNode);
        continue;
    }

    // add folder or file to the current folder
    if (line.StartsWith("dir"))
    {
        currentNode.Children.Add(new FolderNode { Value = line, Parent = currentNode });
    }
    else
    {
        currentNode.Children.Add(new FileNode { Value = line });
    }
    
}

var folderPathToSizeMap = new Dictionary<string, int>();
CountSizeOfFolderRecursevly(rootNode);

var task1Result = folderPathToSizeMap.Where(kvp => kvp.Value <= 100000).Sum(x=> x.Value);
Console.WriteLine($"Task 1 {task1Result}");// 1648397


// task 2
var usedSize = folderPathToSizeMap.First().Value; // root node has total value
var needToPurge = 30000000 - (70000000 - usedSize);
var task2Result = folderPathToSizeMap.Values.MinBy(x => Math.Abs(x - needToPurge));

Console.WriteLine($"Task 2 {task2Result}");// 1815525

int CountSizeOfFolderRecursevly(FolderNode node)
{
    if (!folderPathToSizeMap.ContainsKey(node.FolderPath))
    {
        folderPathToSizeMap.Add(node.FolderPath, 0);
    }

    var files = node.Children
        .OfType<FileNode>()
        .ToList();

    // add size of files in this folder
    var fileSize = files.Sum(x => x.Size);

    var folders = node.Children
        .OfType<FolderNode>()
        .ToList();

    var nestedFolderSize = 0;

    foreach (var folder in folders)
    {
        nestedFolderSize += CountSizeOfFolderRecursevly(folder);
    }

    folderPathToSizeMap[node.FolderPath] += nestedFolderSize + fileSize;

    return nestedFolderSize + fileSize; 
}

static Func<FolderNode, FolderNode> GetCommand(string value)
{
    if (value.StartsWith("$ cd"))
    {
        if (value.Contains(".."))
        {
            return node => node.Parent;
        }

        var directoryToNavigate = Regex.Match(value, """\$ cd (\w+)""").Groups[1].Value;
        return node => (FolderNode)node.Children.First(x => x is FolderNode node && node.FolderName == directoryToNavigate);
    }

    if (value == "$ ls")
    {
        return (node) => node;
    }

    // do nothing by default
    return (node) => node;
}