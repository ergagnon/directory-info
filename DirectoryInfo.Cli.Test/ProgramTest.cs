using FluentAssertions;
using Xunit;

namespace DirectoryInfo.Cli.Test
{
    public class ProgramTest
    {
        [Fact]
        public async void GivenEmptyArg_WhenCallMain_ThenReturnErrorCode()
        {
            var emptyArgs = new string[] { };

            var result = await Program.Main(emptyArgs);

            result.Should().Be(ResultCodes.Error);
        }

        [Fact]
        public async void GivenHelpArg_WhenCallMain_ThenReturnSuccessCode()
        {
            var args = new[] { "--help" };

            var result = await Program.Main(args);

            result.Should().Be(ResultCodes.Success);
        }

        [Fact]
        public async void GivenVersionArg_WhenCallMain_ThenReturnSuccessCode()
        {
            var args = new [] { "--version" };

            var result = await Program.Main(args);

            result.Should().Be(ResultCodes.Success);
        }

        [Theory]
        [InlineData("d")]
        [InlineData("directory")]
        public async void GivenDirectoryCommandWithoutPath_WhenCallMain_ThenReturnErrorCode(string command)
        {
            var args = new [] { command };

            var result = await Program.Main(args);

            result.Should().Be(ResultCodes.Error);
        }

        [Theory]
        [InlineData("d", "C:/dev")]
        [InlineData("directory", "C:/")]
        public async void GivenDirectoryCommandWithPath_WhenCallMain_ThenReturnErrorCode(string command, string path)
        {
            var args = new[] { command, path };

            var result = await Program.Main(args);

            result.Should().Be(ResultCodes.Success);
        }
    }
}
