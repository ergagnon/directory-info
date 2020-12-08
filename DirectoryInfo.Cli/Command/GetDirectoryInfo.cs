using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace DirectoryInfo.Cli.Command
{
    [Command("directory", "d", Description = "Get directory info.")]
    public class GetDirectoryInfo
    {
        [Required]
        [Argument(0, "path", "Directory full path")]
        public string Path { get; set; }

        public Task<int> OnExecuteAsync(IConsole console)
        {
            console.WriteLine($"Directory info of {Path}");
            return Task.FromResult(ResultCodes.Success);
        }
    }
}