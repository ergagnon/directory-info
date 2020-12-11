using System;
using DirectoryInfo.Api.Domain.DirectoryInfoAggregate;
using FluentAssertions;
using Xunit;

namespace DirectoryInfo.Api.Test.Domain.DirectoryInfoAggregate
{
    public class FileInfoTest
    {
        [Fact]
        public void GivenNameSizeAndUpdateTime_WhenCreate_ThenFileInfoCreatedWithCorrectValue()
        {
            var name = "name";
            var size = 23344;
            var updateTime = DateTime.Now;

            var fileInfo = new FileInfo(name, size, updateTime);

            fileInfo.Name.Should().Be(name);
            fileInfo.Size.Should().Be(size);
            fileInfo.UpdatedAt.Should().Be(updateTime);
            fileInfo.FileInfos().Should().BeEmpty();
        }
    }
}