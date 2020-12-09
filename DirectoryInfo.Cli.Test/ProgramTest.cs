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
    }
}
