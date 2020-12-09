using System;
using System.Reflection;
using System.Threading.Tasks;
using DirectoryInfo.Api.Domain.DirectoryInfoAggregate;
using DirectoryInfo.Api.Infrastructure;
using DirectoryInfo.Cli.Command;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DirectoryInfo.Cli
{
    [Command("DirectoryInfo.Cli", Description = "Directory Info Command-line interface.")]
    [Subcommand(typeof(GetDirectoryInfo))]
    [VersionOptionFromMember(MemberName = "GetVersion")]
    [HelpOption]
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) => {
                    services.AddTransient<IDirectoryService, DirectoryService>();
                })
                .RunCommandLineApplicationAsync<Program>(args);
        }

        private static string GetVersion()
        {
            return typeof(Program).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                .InformationalVersion;
        }

        private int OnExecute(CommandLineApplication app)
        {  
            app.Error.Write(app.Error.NewLine);          
            app.Error.WriteLine("Invalid command. See help information below.");
            app.Error.Write(app.Error.NewLine);
            
            app.ShowHelp();
            return ResultCodes.Error;
        }
    }
}
