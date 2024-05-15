using FluentAssertions;
using MarkdownParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownParserTests
{
    public class ConvertionToEscapeTests
    {
        [Theory]
        // Paragraph
        [InlineData("Hello world\n\nI am Lucifer", "Hello world\r\n\nI am Lucifer\r\n")]
        [InlineData("Hello world\n\n\n\n\n\n\n\n\nI am Lucifer", "Hello world\r\n\nI am Lucifer\r\n")]
        // Bold
        [InlineData("Hello **world**", "Hello \x1b[1mworld\x1b[0m\r\n")]
        [InlineData("Hello **_** world", "Hello \x1b[1m_\x1b[0m world\r\n")]
        [InlineData("Hello ** world", "Hello ** world\r\n")]
        [InlineData("Hello world. I am **Luci**fer**", "Hello world. I am \x1b[1mLuci**fer\x1b[0m\r\n")]
        [InlineData("**Hello world**. I am Lucifer", "\x1b[1mHello world\x1b[0m. I am Lucifer\r\n")]
        // Italic
        [InlineData("Hello _world_", "Hello \x1b[3mworld\x1b[0m\r\n")]
        [InlineData("Hello _ world", "Hello _ world\r\n")]
        [InlineData("Hello _**_ world", "Hello \x1b[3m**\x1b[0m world\r\n")]
        [InlineData("Hello world. I am _Lu**ci_fer_", "Hello world. I am \x1b[3mLu**ci_fer\x1b[0m\r\n")]
        [InlineData("_Hello world_: I am Lucifer", "\x1b[3mHello world\x1b[0m: I am Lucifer\r\n")]
        // Monospace
        [InlineData("Hello `world`", "Hello \x1b[7mworld\x1b[0m\r\n")]
        [InlineData("Hello ` world", "Hello ` world\r\n")]
        [InlineData("Hello `**` world", "Hello \x1b[7m**\x1b[0m world\r\n")]
        [InlineData("Hello world. I am `Lu**ci`fer`", "Hello world. I am \x1b[7mLu**ci`fer\x1b[0m\r\n")]
        [InlineData("`Hello world`; I am Lucifer", "\x1b[7mHello world\x1b[0m; I am Lucifer\r\n")]
        // Preformatted text
        [InlineData("```\r\nHello world\r\n```", "\x1b[7mHello world\u001b[0m\r\n")]
        [InlineData("```\r\nHello _world_. _**_ I **am** `Lucifer`\r\n```", "\x1b[7mHello _world_. _**_ I **am** `Lucifer`\u001b[0m\r\n")]
        [InlineData("Hello\n\n\n```\r\nworld\n\n\n\nworld\r\n```", "Hello\r\n\n\x1b[7mworld\n\n\n\nworld\u001b[0m\r\n")]
        public void ConvertToEscape_WorksFine_IfMarkdownConvertedToHtmlCorrectly(string markdown, string expectedEscape)
        {
            string actualEscape = markdown.ConvertToEscape();

            actualEscape.Should().Be(expectedEscape);
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
        public void ConvertToEscape_ThrowsInvalidOperationException_IfIncorrectNestedMarkup(string markdown, string expectedExceptionMessage)
        {
            Assert.Throws<InvalidOperationException>(() => markdown.ConvertToEscape()).
                Message.Should().Be($"Not finished markup: {expectedExceptionMessage}");
        }

        [Theory]
        [InlineData("**Hello _some_ world** ", "\x1b[1mHello _some_ world\x1b[0m")]
        [InlineData("_Hello `some` world_ ", "\x1b[3mHello `some` world\x1b[0m")]
        public void ConvertToEscape_ThrowsInvalidOperationException_IfNotFinishedMarkup(string markdown, string expectedExceptionMessage)
        {
            Assert.Throws<InvalidOperationException>(() => markdown.ConvertToEscape()).
                Message.Should().Be($"Incorrect nested markup: {expectedExceptionMessage}");
        }
    }
}
