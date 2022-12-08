using System.Text.RegularExpressions;

namespace Day7
{
    public class FileNode : Node
    {
        private int? _size;

        public int Size => _size ??= int.Parse(Regex.Match(Value!, "(\\d+) \\w+").Groups[1].Value);
    }
}
