# Markdown Parser

This console application allows you to parse markdown into html.

The result can be displayed in the console or saved to a file.

This application suports both Windows and Linux operating systems.

## How to set up it locally?

### Windows 

In this instruction is used Windows CMD

Firstly, clone this repo using web URL:

```cmd
git clone https://github.com/HlibPavlyk/MarkdowmParser.git
```

or via SSH certificate:

```cmd
git clone git@github.com:HlibPavlyk/MarkdowmParser.git
```

Then move to that repo:

```cmd
cd MarkdownParser
```

Run application:

```cmd
MarkdownParser-win.exe -i <path> -o <path> 
```

### Linux

In this instruction is used Bash

Firstly, clone this repo using web URL:

```bash
git clone https://github.com/HlibPavlyk/MarkdowmParser.git
```

or via SSH certificate:

```bash
git clone git@github.com:HlibPavlyk/MarkdowmParser.git
```

Then move to that repo:

```bash
cd /MarkdownParser
```

Change accessebility mode:

```bash
chmod +x MarkdownParser-linux
```

Run application:

```bash
./MarkdownParser-linux -i <path> -o <path> 
```


## Explore all commands

To see all options use argument ```--help```

```cmd
MarkdownParser 1.0.0
Copyright (C) 2024 MarkdownParser

  -i, --input     Required. Input file .txt path.

  -o, --output    Output file .html path.

  --help          Display this help screen.

  --version       Display version information.
```

## Example

Lets parse text file with Markdown markup test.txt and save result to test.html using Windows version:

### text.txt

```markdown
Вовки загнали собаку, `_` оточили, **хочуть зжерти**. Собака просить не вбивати її, натомість обіцяє допомагати заганяти овець та іншу худобу.

Вовки ** подумали і залишили собаку в зграї. Два роки вона їм допомагала, всьому вчила, показувала місця, полювала разом з ними...
Настала особливо _голодна_зима_, `полювання*нев_далі`, _вовки_ голодні, зневірені. Що робити? Вирішили все-таки зжерти собаку. Зжерли. Кісточки поховали.





``
Поставили надгробок. `Думають`, як підписати, від кого? **Від друзів?** Так начебто які ж вони друзі, раз зжерли... _Від_ворогів?_ Так 2 роки разом пліч-о-пліч
``
жили, полювали, ніхто в образі не був... Подумали і написали `Від колег`.
```

### Parse it:

```cmd
MarkdownParser-win.exe -i test.txt -o test.html 
```

### test.html :

```html
<p>Вовки загнали собаку, <tt>_</tt> оточили, <b>хочуть зжерти</b>. Собака просить не вбивати її, натомість обіцяє допомагати заганяти овець та іншу худобу.</p>
<p>Вовки ** подумали і залишили собаку в зграї. Два роки вона їм допомагала, всьому вчила, показувала місця, полювала разом з ними...
Настала особливо <i>голодна_зима</i>, <tt>полювання*нев_далі</tt>, <i>вовки</i> голодні, зневірені. Що робити? Вирішили все-таки зжерти собаку. Зжерли. Кісточки поховали.</p>
<p><pre>
Поставили надгробок. `Думають`, як підписати, від кого? **Від друзів?** Так начебто які ж вони друзі, раз зжерли... _Від_ворогів?_ Так 2 роки разом пліч-о-пліч
</pre>
жили, полювали, ніхто в образі не був... Подумали і написали <tt>Від колег</tt>.</p>
```

## Revert Commit

[Link](https://github.com/fokaaas/markdown-parser/commit/583d2de561e477b049711f8b901ca9fbfe9747cf)
