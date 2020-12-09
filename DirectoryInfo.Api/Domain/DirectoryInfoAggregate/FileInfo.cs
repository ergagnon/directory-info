using System;
using System.Collections.Generic;

namespace DirectoryInfo.Api.Domain.DirectoryInfoAggregate
{
    public class FileInfo : AbstractFileInfo
    {
        public string Name { get; }
        public long Size { get; }
        public DateTime UpdatedAt { get; }
 
        public FileInfo(string name, long size, DateTime updatedAt)
        {
            Name = name;
            Size = size;
            UpdatedAt = updatedAt;
        }

        public IReadOnlyList<AbstractFileInfo> FileInfos() => new List<AbstractFileInfo>();
    }
}