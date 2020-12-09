using System;
using System.Collections.Generic;

namespace DirectoryInfo.Api.Domain.DirectoryInfoAggregate
{
    public interface AbstractFileInfo
    {
        string Name { get; }
        long Size { get; }
        DateTime UpdatedAt { get; }
        IReadOnlyList<AbstractFileInfo> FileInfos();
    }
}