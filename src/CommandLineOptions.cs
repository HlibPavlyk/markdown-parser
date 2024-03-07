using CommandLine;

namespace MarkdownParser
{
    public class CommandLineOptions
    {

        [Option('i', "input", Required = true, HelpText = "Input file .txt path.")]
        public string InputFilePath { get; set; }

        [Option('o', "output", Required = false, HelpText = "Output file .html path.")]
        public string OutputFilePath { get; set; }

    }
}
