using CommandLine;
using MarkdownParser;

Console.OutputEncoding = System.Text.Encoding.UTF8;

/*string content = FileOperations.ReadFileContent("test.txt");
content = content.ConvertToHtml();
Console.WriteLine(content);*/

Parser.Default.ParseArguments<CommandLineOptions>(args)
       .WithParsed(options =>
       {
           try
           {
               string content = FileOperations.ReadFileContent(options.InputFilePath);
               content = content.ConvertToHtml();

               if (options.OutputFilePath == null)
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
               Console.Error.WriteLine($"Wrong: {ex.Message}");
               Environment.Exit(1);
           }
       });
