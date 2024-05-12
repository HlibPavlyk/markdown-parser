using FluentAssertions;
using MarkdownParser;

namespace MarkdownParserTests.ConvertionToHtmlTests
{
    public class ConvertionToHtmlTests
    {
        [Theory]
        // Paragraph
        [InlineData("Hello world", "<p>Hello world</p>")]
        [InlineData("Hello world\n\nI am Lucifer", "<p>Hello world</p>\n<p>I am Lucifer</p>")]
        [InlineData("Hello world\n\n\n\n\n\n\n\n\nI am Lucifer", "<p>Hello world</p>\n<p>I am Lucifer</p>")]
        [InlineData("Hello world\nI am Lucifer", "<p>Hello world\nI am Lucifer</p>")]
        // Bold
        [InlineData("Hello **world**", "<p>Hello <b>world</b></p>")]
        [InlineData("Hello **_** world", "<p>Hello <b>_</b> world</p>")]
        [InlineData("Hello ** world", "<p>Hello ** world</p>")]
        [InlineData("Hello world. I am **Luci**fer**", "<p>Hello world. I am <b>Luci**fer</b></p>")]
        [InlineData("**Hello world**. I am Lucifer", "<p><b>Hello world</b>. I am Lucifer</p>")]
        // Italic
        [InlineData("Hello _world_", "<p>Hello <i>world</i></p>")]
        [InlineData("Hello _ world", "<p>Hello _ world</p>")]
        [InlineData("Hello _**_ world", "<p>Hello <i>**</i> world</p>")]
        [InlineData("Hello world. I am _Lu**ci_fer_", "<p>Hello world. I am <i>Lu**ci_fer</i></p>")]
        [InlineData("_Hello world_: I am Lucifer", "<p><i>Hello world</i>: I am Lucifer</p>")]
        // Monospace
        [InlineData("Hello `world`", "<p>Hello <tt>world</tt></p>")]
        [InlineData("Hello ` world", "<p>Hello ` world</p>")]
        [InlineData("Hello `**` world", "<p>Hello <tt>**</tt> world</p>")]
        [InlineData("Hello world. I am `Lu**ci`fer`", "<p>Hello world. I am <tt>Lu**ci`fer</tt></p>")]
        [InlineData("`Hello world`; I am Lucifer", "<p><tt>Hello world</tt>; I am Lucifer</p>")]
        // Preformatted text
        [InlineData("```\r\nHello world\r\n```", "<p><pre>\r\nHello world\r\n</pre></p>")]
        [InlineData("```\r\nHello _world_. _**_ I **am** `Lucifer`\r\n```", "<p><pre>\r\nHello _world_. _**_ I **am** `Lucifer`\r\n</pre></p>")]
        [InlineData("Hello\n\n\n```\r\nworld\n\n\n\nworld\r\n```", "<p>Hello</p>\n<p><pre>\r\nworld\n\n\n\nworld\r\n</pre></p>")]
        public void ConvertToHtml_WorksFine_IfMarkdownConvertedToHtmlCorrectly(string markdown, string expectedHtml)
        {
            string actualHtml = markdown.ConvertToHtml();

            actualHtml.Should().Be(expectedHtml);
        }

        [Theory]
        // Bold
        [InlineData("Hello **world ", "**world")]
        [InlineData("Hello ****world ", "****world")]
        [InlineData("Hello **** world ", "****")]
        // Italic
        [InlineData("Hello world_ ", "world_")]
        [InlineData("Hello _world ", "_world")]
        [InlineData("Hello __ world ", "__")]
        // Monospace
        [InlineData("Hello `world ", "`world")]
        [InlineData("Hello `` world ", "``")]
        public void ConvertToHtml_ThrowsInvalidOperationException_IfIncorrectNestedMarkup(string markdown, string expectedExceptionMessage)
        {
            Assert.Throws<InvalidOperationException>(()  => markdown.ConvertToHtml()).
                Message.Should().Be($"Not finished markup: {expectedExceptionMessage}");
        }

        [Theory]
        [InlineData("**Hello _some_ world** ", "<b>Hello _some_ world</b>")]
        [InlineData("_Hello `some` world_ ", "<i>Hello `some` world</i>")]
        public void ConvertToHtml_ThrowsInvalidOperationException_IfNotFinishedMarkup(string markdown, string expectedExceptionMessage)
        {
            Assert.Throws<InvalidOperationException>(() => markdown.ConvertToHtml()).
                Message.Should().Be($"Incorrect nested markup: {expectedExceptionMessage}");
        }
    }
}