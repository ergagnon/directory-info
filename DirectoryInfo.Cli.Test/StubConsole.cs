using System;
using System.IO;
using McMaster.Extensions.CommandLineUtils;

namespace DirectoryInfo.Cli.Test
{
    internal class StubConsole : IConsole
    {
        public TextWriter Out => new StringWriter();

        public TextWriter Error => new StringWriter();

        public TextReader In => new StringReader("test");

        public bool IsInputRedirected => false;

        public bool IsOutputRedirected => false;

        public bool IsErrorRedirected => false;

        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }

        public event ConsoleCancelEventHandler CancelKeyPress;

        public void ResetColor()
        {
            
        }
    }
}