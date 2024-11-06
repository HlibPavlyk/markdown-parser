# Markdown Parser

Markdown Parser is a console application that enables you to parse Markdown into HTML and Escape ANSI. The resulting output can be either displayed in the console or saved to a file.

This application supports both Windows and Linux operating systems.

## Features:

- **Parse Markdown to HTML:** Convert Markdown-formatted text into HTML.
- **Flexible Output Formats:** Choose between different output formats such as HTML and escaped ANSI.
  
### Supported Operating Systems:

- **Windows:** The application can be run on Windows operating systems using the Windows Command Prompt.
- **Linux:** Similarly, it can be executed on Linux systems using the terminal.

## How to set it up locally?

### Windows

This instruction utilizes Windows CMD.

#### Cloning the Repository

Firstly, clone this repository using either the web URL:

```cmd
git clone https://github.com/HlibPavlyk/markdown-parser.git
```

or via SSH certificate:

```cmd
git clone git@github.com:HlibPavlyk/markdown-parser.git
```

#### Moving to the Repository

Then navigate to the cloned repository:

```cmd
cd markdown-parser
```

#### Running the Application

Run the application using the following command:

```cmd
MarkdownParser-win.exe --input <path> --output <path> --format <type>
```

### Linux

#### Cloning the Repository

Firstly, clone this repository using either the web URL:

```bash
git clone https://github.com/HlibPavlyk/markdown-parser.git
```

or via SSH certificate:

```bash
git clone git@github.com:HlibPavlyk/markdown-parser.git
```

#### Moving to the Repository

Then navigate to the cloned repository:

```bash
cd markdown-parser/
```

#### Changing Accessibility Mode

Change the accessibility mode for the application:

```bash
chmod +x MarkdownParser-linux
```

#### Running the Application

Run the application using the following command:

```bash
./MarkdownParser-linux --input <path> --output <path> --format <type>
```

## Running Tests

The application includes a comprehensive suite of unit tests to ensure its functionality and reliability. Currently, there are 62 unit tests implemented within the program.

To run tests in this project, you need to have the .NET SDK installed. If you don't have it yet, you can download it from the [official .NET website](https://dotnet.microsoft.com/download) or via console in linux.

After installing the .NET SDK, you can follow these steps to run the tests:

1. **Open the terminal**:

   Open the command prompt (on Windows) or terminal (on macOS or Linux).

2. **Navigate to the project directory**:

   Use the `cd` command to navigate to the `markdown-parser` directory, as we did in the previous paragraph.

3. **Run the `dotnet test` command**:

   Once you're in the root directory of your project, enter the following command to run the tests:

   ```bash
   dotnet test
   ```

   This will execute all tests in your project and display the results in your terminal.

   If you are using Linux, ensure that you have appropriate permissions to execute the `dotnet` command and that your project is compatible with the Linux environment.

## Explore all commands

To see all options use argument ```--help```

```cmd
MarkdownParser 1.0.0
Copyright (C) 2024 MarkdownParser

  -i, --input     Required. Input file .txt path.

  -o, --output    Output file .html path.

  -f, --format    Output format (escape/html)

  --help          Display this help screen.

  --version       Display version information.
```

## Example

Lets parse text file with Markdown markup test.txt and test 2 different scenarios using Windows version:
- save result to test_html.html using HTML;
- save result to test_escape.html using Escape ANSI;

### text.txt

```markdown
Вовки загнали собаку, `_` оточили, **хочуть зжерти**. Собака просить не вбивати її, натомість обіцяє допомагати заганяти овець та іншу худобу.

Вовки ** подумали і залишили собаку в зграї. Два роки вона їм допомагала, всьому вчила, показувала місця, полювала разом з ними...
Настала особливо _голодна_зима_, `полювання*нев_далі`, _вовки_ голодні, зневірені. Що робити? Вирішили все-таки зжерти собаку. Зжерли. Кісточки поховали.





'''
Поставили надгробок. `Думають`, як підписати, від кого? **Від друзів?** Так начебто які ж вони друзі, раз зжерли... _Від_ворогів?_ Так 2 роки разом пліч-о-пліч
'''
жили, полювали, ніхто в образі не був... Подумали і написали `Від колег`.
```

### First scenario:

```cmd
MarkdownParser-win.exe -i test.txt -o test_html.html 
```

### test_html.html:

```html
<p>Вовки загнали собаку, <tt>_</tt> оточили, <b>хочуть зжерти</b>. Собака просить не вбивати її, натомість обіцяє допомагати заганяти овець та іншу худобу.</p>
<p>Вовки ** подумали і залишили собаку в зграї. Два роки вона їм допомагала, всьому вчила, показувала місця, полювала разом з ними...
Настала особливо <i>голодна_зима</i>, <tt>полювання*нев_далі</tt>, <i>вовки</i> голодні, зневірені. Що робити? Вирішили все-таки зжерти собаку. Зжерли. Кісточки поховали.</p>
<p><pre>
Поставили надгробок. `Думають`, як підписати, від кого? **Від друзів?** Так начебто які ж вони друзі, раз зжерли... _Від_ворогів?_ Так 2 роки разом пліч-о-пліч
</pre>
жили, полювали, ніхто в образі не був... Подумали і написали <tt>Від колег</tt>.</p>
```

### Second scenario:

```cmd
MarkdownParser-win.exe -i test.txt -o test_escape.html -f escape
```

### test_escape.html:

```html
Вовки загнали собаку, [7m_[0m оточили, [1mхочуть зжерти[0m. Собака просить не вбивати її, натомість обіцяє допомагати заганяти овець та іншу худобу.

Вовки ** подумали і залишили собаку в зграї. Два роки вона їм допомагала, всьому вчила, показувала місця, полювала разом з ними...
Настала особливо [3mголодна_зима[0m, [7mполювання*нев_далі[0m, [3mвовки[0m голодні, зневірені. Що робити? Вирішили все-таки зжерти собаку. Зжерли. Кісточки поховали.

[7mПоставили надгробок. `Думають`, як підписати, від кого? **Від друзів?** Так начебто які ж вони друзі, раз зжерли... _Від_ворогів?_ Так 2 роки разом пліч-о-пліч[0m
жили, полювали, ніхто в образі не був... Подумали і написали [7mВід колег[0m.
```

## Revert Commit

[Link](https://github.com/HlibPavlyk/MarkdownParser/commit/6e47e0ac087f7d7d18733909c18696cd5cfe9777)

## Commit with failed GitHub Action

[Link](https://github.com/HlibPavlyk/MarkdownParser/commit/3ac2a340deb3d1a4ecc0e1a1695e44904ef71048)

## Conclusion

Even when working solo, unit tests can be immensely valuable. They act as a safety net, catching potential issues early on and ensuring the reliability of your codebase. In my experience, having a suite of unit tests provides peace of mind and confidence in the correctness of my code, allowing me to focus on implementing new features or making changes without fear of inadvertently introducing bugs. Additionally, unit tests serve as documentation for the expected behavior of your code, making it easier to understand and maintain over time. So, even if you're working alone, investing time in writing unit tests can ultimately save you time and effort by preventing future headaches and debugging sessions.



