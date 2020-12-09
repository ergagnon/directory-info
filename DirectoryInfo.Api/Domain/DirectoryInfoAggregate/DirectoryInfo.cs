using System;
using System.Collections.Generic;
using System.Linq;

namespace DirectoryInfo.Api.Domain.DirectoryInfoAggregate
{
    public class DirectoryInfo : AbstractFileInfo
    {
        public string Name { get; }
        public long Size => fileInfos.Sum(x => x.Size);
        public DateTime UpdatedAt { get; }

        private List<AbstractFileInfo> fileInfos = new List<AbstractFileInfo>();

        public DirectoryInfo(string name, DateTime updatedAt)
        {
            Name = name;
            UpdatedAt = updatedAt;
        }

        public void Add(AbstractFileInfo fileInfo)
        {
            fileInfos.Add(fileInfo);
        }

        public IReadOnlyList<AbstractFileInfo> FileInfos()
        {
            fileInfos.Sort((x, y) => x.Size.CompareTo(y.Size));
            return fileInfos;
        }
    }
}