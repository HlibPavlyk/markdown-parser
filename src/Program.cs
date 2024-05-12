using CommandLine;
using MarkdownParser;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Parser.Default.ParseArguments<CommandLineOptions>(args)
    .WithParsed(options =>
    {
        try
        {
            string content = FileOperations.ReadFileContent(options.InputFilePath);

            if (!string.IsNullOrEmpty(options.OutputFormat))
            {
                switch (options.OutputFormat.ToLower())
                {
                    case "escape":
                        content = content.ConvertToEscape();
                        break;
                    case "html":

                        content = content.ConvertToHtml();
                        break;
                    default:

                        Console.Error.WriteLine($"Unknown format: {options.OutputFormat}");
                        Environment.Exit(1);
                        break;
                }
            }
            else if(string.IsNullOrEmpty(options.OutputFilePath))
            {
                content = content.ConvertToEscape();
            }
            else
            {
                content = content.ConvertToHtml();
            }
            

            if (string.IsNullOrEmpty(options.OutputFilePath))
            {
                Console.WriteLine(content);
            }
            else
            {
                FileOperations.WriteToHtmlFile(options.OutputFilePath, content);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    });
