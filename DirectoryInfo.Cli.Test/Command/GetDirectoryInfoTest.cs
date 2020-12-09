using System;
using DirectoryInfo.Api.Domain.DirectoryInfoAggregate;
using DirectoryInfo.Cli.Command;
using FluentAssertions;
using Moq;
using Xunit;

namespace DirectoryInfo.Cli.Test.Command
{
    public class GetDirectoryInfoTest
    {
        private readonly Mock<IDirectoryService> service = new Mock<IDirectoryService>();

        [Fact]
        public void GivenGetDirectoryInfoWithValidPath_WhenOnExcecute_ThenReturnSuccessCode()
        {
            service.Setup(x => x.GetInfo(It.IsAny<string>())).Returns(new FileInfo("a", 1, DateTime.Now));
            
            var getDirectoryInfo = new GetDirectoryInfo(service.Object, new StubConsole());
            getDirectoryInfo.Path = "C:/";

            var result = getDirectoryInfo.OnExecute();

            result.Should().Be(ResultCodes.Success);
        }

        [Fact]
        public void GivenGetDirectoryInfoAndServiceReturnNullDirectoryInfo_WhenOnExcecute_ThenReturnErrorCode()
        {
            AbstractFileInfo fileInfo = null;
            service.Setup(x => x.GetInfo(It.IsAny<string>())).Returns(fileInfo);
            
            var getDirectoryInfo = new GetDirectoryInfo(service.Object, new StubConsole());
            getDirectoryInfo.Path = "C:/";

            var result = getDirectoryInfo.OnExecute();

            result.Should().Be(ResultCodes.Error);
        }

        [Fact]
        public void GivenGetDirectoryInfoAndServiceeException_WhenOnExcecute_ThenReturnErrorCode()
        {
            service.Setup(x => x.GetInfo(It.IsAny<string>())).Throws(new Exception());
            
            var getDirectoryInfo = new GetDirectoryInfo(service.Object, new StubConsole());
            getDirectoryInfo.Path = "C:/";

            var result = getDirectoryInfo.OnExecute();

            result.Should().Be(ResultCodes.Error);
        }
    }
}