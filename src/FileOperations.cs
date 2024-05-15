using System.Text;

namespace MarkdownParser
{
    public static class FileOperations
    {
        public static string ReadFileContent(string? filePath)
        {
            if (!File.Exists(filePath) || string.IsNullOrEmpty(filePath))
            {
                throw new FileNotFoundException($"File '{filePath}' not found");
            }

            if (!filePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Invalid file extension. File must end with '.md'.");
            }

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static void WriteToHtmlFile(string filePath, string content)
        {
            if (!filePath.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Invalid file extension. File must end with '.html'.");
            }

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    writer.Write(content);
                }
            }
        }
    }
}
