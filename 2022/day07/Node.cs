using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7
{
    [DebuggerDisplay("{Value}")]
    public abstract class Node
    {
        public string? Value { get; init; }

        public List<Node> Children { get; } = new List<Node>();

        public void Traverse(Action<Node> action)
        {
            action(this);
            foreach (var child in Children)
                child.Traverse(action);
        }
    }
}
