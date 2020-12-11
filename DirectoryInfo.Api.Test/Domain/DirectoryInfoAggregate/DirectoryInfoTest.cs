using System;
using System.Collections.Generic;
using DirectoryInfo.Api.Domain.DirectoryInfoAggregate;
using FluentAssertions;
using Xunit;
using DomainDirectoryInfo = DirectoryInfo.Api.Domain.DirectoryInfoAggregate.DirectoryInfo;

namespace DirectoryInfo.Api.Test.Domain.DirectoryInfoAggregate
{
    public class DirectoryInfoTest
    {
        [Fact]
        public void GivenNameAndUpdateTime_WhenCreate_ThenDirectoryInfoCreatedWithCorrectValue()
        {
            var name = "name";
            var updateTime = DateTime.Now;

            var dirInfo = new DomainDirectoryInfo(name, updateTime);

            dirInfo.Name.Should().Be(name);
            dirInfo.Size.Should().Be(0);
            dirInfo.UpdatedAt.Should().Be(updateTime);
            dirInfo.FileInfos().Should().BeEmpty();
        }

        [Fact]
        public void GivenDirectoryInfo_WhenAddFileInfo_ThenSizeIsAdded()
        {
            var name = "name";
            var updateTime = DateTime.Now;

            var dirInfo = new DomainDirectoryInfo(name, updateTime);

            var fileSize = 10;
            dirInfo.Add(new FileInfo("", fileSize, updateTime));
            dirInfo.Add(new FileInfo("", fileSize, updateTime));

            dirInfo.Size.Should().Be(fileSize+fileSize);
        } 

        [Fact]
        public void GivenDirectoryInfo_WhenAddFileInfoWithDifferentSize_ThenFileInfosIsSortedAscBySize()
        {
            var name = "name";
            var updateTime = DateTime.Now;

            var dirInfo = new DomainDirectoryInfo(name, updateTime);
            
            var fileSize200 = new FileInfo("", 200, updateTime);
            var fileSize100 = new FileInfo("", 100, updateTime); 
            dirInfo.Add(fileSize200);
            dirInfo.Add(fileSize100);

            dirInfo.FileInfos().Should().BeEquivalentTo(new List<AbstractFileInfo> {fileSize100, fileSize200});
        }          
    }
}