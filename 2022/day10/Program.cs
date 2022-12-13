using System.Text.RegularExpressions;

var inputFile = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "input.txt"));
var input = inputFile.Split(Environment.NewLine).ToList();

var task1Result = 0;
var totalRegister = 1;
var tickCount = 1;

for (int i = 0; i < input.Count; i++)
{
    var command = input[i];

    if (command == "noop")
    {
        Tick();
    }
    else
    {
        Tick();
        Tick();

        var register = int.Parse(Regex.Match(command, @"addx (-?\d+)").Groups[1].ValueSpan);
        totalRegister += register;
    }
}

void Tick()
{
    const int startValue = 20;
    const int delta = 40;

    if (((tickCount - startValue) % delta) == 0)
    {
        task1Result += totalRegister * (tickCount);
    }

    Draw();

    tickCount++;
}

void Draw()
{
    var sprite = (tickCount - 1) % 40;

    if (sprite == 0)
    {
        Console.WriteLine();
    }

    if (sprite == totalRegister || sprite == totalRegister - 1 || sprite == totalRegister + 1)
    {
        Console.Write("#");
    }
    else
    {
        Console.Write(".");
    }
}

Console.WriteLine($"Task 1 result {task1Result}"); //15120
Console.WriteLine($"Task 1 result RKPJBPLA"); //RKPJBPLA
