using System.Text.RegularExpressions;

namespace MarkdownParser
{
    public static class RegexExtension
    {
        private static readonly List<RegexModel> regexModels = new List<RegexModel>
        {
            new RegexModel(@"(?<=[ ,.:;>\n\t]|^)\*\*(?=\S)(.+?)(?<=\S)\*\*(?=[ ,.:;<\n\t]|$)", "<b>$1</b>"),
            new RegexModel(@"(?<=[ ,.:;>\n\t]|^)_(?=\S)(.+?)(?<=\S)_(?=[ ,.:;<\n\t]|$)", "<i>$1</i>"),
            new RegexModel(@"(?<=[ ,.:;>\n\t]|^)\`(?=\S)(.+?)(?<=\S)\`(?=[ ,.:;<\n\t]|$)", "<tt>$1</tt>")
        };
        private static readonly string preformattedTextModelPattern = @"`\`\`\r?\n([\s\S]*?)\r?\n\`\`\`";
        private static readonly string preformattedTextModelRevertPattern = @"<pre>(.+?)</pre>";
        private static readonly string paragraphModelPattern = @"(?:\r?\n){2,}";
        private static readonly string notFinishedModelPattern = @"(?<=[ ,.;:\n\t]|^)(\*\*|_|\`|\`\`\`)\S+|\S+(\*\*|_|\`|\`\`\`)(?=[ ,.;:\n\t]|$)";
        private static readonly int offsetPreformattedText = 5;


        public static string ConvertToHtml(this string data)
        {
            List<string> preformattedTextList;
            (data, preformattedTextList) = RemovePreformattedText(data);

            data = ProcessParagraph(data);

            foreach (var regexModel in regexModels)
            {
                data = ProcessRegexModel(data, regexModel);
            }

            ProcessSpecialCharacters(data);
            data = AddPreformattedText(data, preformattedTextList);

            return data;
        }

        private static string ProcessRegexModel(string data, RegexModel regexModel)
        {
            string pattern = regexModel.Pattern;
            string replacement = regexModel.Replacement;

            MatchCollection matches = Regex.Matches(data, pattern);
            foreach (Match match in matches)
            {
                string originalMatch = match.Value;
                string replacedMatch = Regex.Replace(originalMatch, pattern, replacement);
                data = data.Replace(originalMatch, replacedMatch);

                foreach (var regModelCheking in regexModels)
                {
                    if (Regex.IsMatch(replacedMatch, regModelCheking.Pattern))
                        throw new InvalidOperationException($"Incorrect nested markup: {replacedMatch}");
                }
            }

            return data;
        }

        private static (string, List<string>) RemovePreformattedText(string data)
        {
            List<string> removedTexts = new List<string>();

            MatchCollection matches = Regex.Matches(data, preformattedTextModelPattern);
            foreach (Match match in matches)
            {
                string removedText = match.Value;

                removedTexts.Add(removedText.Substring(offsetPreformattedText, removedText.Length - 2 * offsetPreformattedText));
            }

            int index = 0;
            data = Regex.Replace(data, preformattedTextModelPattern, match =>
            {
                string replacement = $"<pre>{index}</pre>";
                index++;

                return replacement;
            });

            return (data, removedTexts);
        }

        private static string AddPreformattedText(string data, List<string> preformattedTextList)
        {
            MatchCollection matches = Regex.Matches(data, preformattedTextModelRevertPattern);

            foreach (Match match in matches)
            {
                string replacement = $"<pre>\r\n{preformattedTextList[Convert.ToInt32(match.Groups[1].Value)]}\r\n</pre>";
                data = Regex.Replace(data, match.Value, replacement);
            }

            return data;
        }

        private static string ProcessParagraph(string data)
        {
            string[] paragraphs = Regex.Split(data, paragraphModelPattern);

            for (int i = 0; i < paragraphs.Length; i++)
            {
                paragraphs[i] = $"<p>{paragraphs[i]}</p>";
            }

            return string.Join("\n", paragraphs);

        }

        private static void ProcessSpecialCharacters(string data)
        {
            MatchCollection matches = Regex.Matches(data, notFinishedModelPattern);
            foreach (Match match in matches)
            {
                throw new InvalidOperationException($"Not finished markup: {match.Value}");
            }
        }
    }
}
