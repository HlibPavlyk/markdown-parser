namespace MarkdownParser
{
    public class RegexModel
    {
        public string Pattern { get; }
        public string Replacement { get; }

        public RegexModel(string pattern, string replacement)
        {
            Pattern = pattern;
            Replacement = replacement;
        }
    }
}
