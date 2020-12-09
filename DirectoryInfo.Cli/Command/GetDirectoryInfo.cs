using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DirectoryInfo.Api.Domain.DirectoryInfoAggregate;
using McMaster.Extensions.CommandLineUtils;

namespace DirectoryInfo.Cli.Command
{
    [Command("directory", "d", Description = "Get directory info.")]
    public class GetDirectoryInfo
    {
        [Required]
        [Argument(0, "path", "Directory full path")]
        public string Path { get; set; }

        private readonly IDirectoryService directoryService;
        private readonly IConsole console;

        public GetDirectoryInfo(IDirectoryService directoryService, IConsole console)
        {
            this.directoryService = directoryService;
            this.console = console;
        }

        public int OnExecute()
        {
            var result = ResultCodes.Success;
            try
            {
                console.WriteLine($"Getting Directory info of {Path}");
                var directoryTree = directoryService.GetInfo(Path);
                PrintTree(directoryTree);
            }
            catch (Exception ex)
            {
                console.ForegroundColor = ConsoleColor.Red;
                console.WriteLine($"Error while getting directory info. Error description: {ex.Message}.");
                console.ForegroundColor = ConsoleColor.White;
                result = ResultCodes.Error;
            }
            
            return result;
        }

        private void PrintTree(AbstractFileInfo tree, string indent="", bool last=false)
        {
            console.ForegroundColor = ConsoleColor.Blue;
            console.WriteLine($"{indent}+- {tree.Name} || {tree.Size} bytes || Modified at {tree.UpdatedAt}");
            indent += last ? "   " : "|  ";

            for (int i = 0; i < tree.FileInfos().Count; i++)
            {
                PrintTree(tree.FileInfos()[i], indent, i == tree.FileInfos().Count - 1);
            }
            console.ForegroundColor = ConsoleColor.White;
        }
    }
}