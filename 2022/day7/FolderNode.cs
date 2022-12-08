using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day7
{
    public class FolderNode : Node
    {
        private string? _folderName;
        private string? _folderPath;

        public FolderNode? Parent { get; init; }

        public string FolderName => _folderName ??= Regex.Match(Value!, """dir (\w+)""").Groups[1].Value;

        public string FolderPath
        {
            get
            {
                if (_folderPath == null)
                {
                    var sb = new StringBuilder();
                    sb.Append(string.IsNullOrEmpty(FolderName) ? "root" : FolderName);
                    var currentParent = Parent;

                    while (currentParent != null)
                    {
                        sb.Append("-");
                        sb.Append(currentParent.FolderName);
                        currentParent = currentParent.Parent;
                    }

                    _folderPath = sb.ToString();
                }

                return _folderPath;
            }
        }
    }
}
