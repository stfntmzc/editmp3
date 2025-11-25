# editmp3

A simple command-line tool for batch-editing MP3 metadata using **TagLib#**.  
This project is currently in **very early development** and intended mainly for personal use.

---

## Features

- Modify MP3 tags (album, author, year, genre, composers)
- Apply multiple edits in a single command
- Optionally specify which files to modify
- Automatically processes all `.mp3` files in the working directory if no files are specified

---

## Usage

Run the tool with:

```bash
dotnet run [commands...]
```
Commands begin with - and are followed by arguments. Arguments are separated by spaces. If an argument contains spaces, it should be wrapped in ". You can chain multiple commands together.

If the -files command is used, only those specified files will be edited.
Otherwise, all .mp3 files in the current directory are processed.

## Available Commands
### -set-author

Sets the Performers tag.
```bash
-set-author <name1> <name2> ...
```

Example:
```bash
dotnet run -set-author "Mike" "Jeff Bezos"
```
### -set-album

Sets the Album tag.
```bash
-set-album <albumName>
```

Example:
```bash
dotnet run -set-album "Dark Side of the Moon"
```
### -set-genre

Sets the Genre tag.
```bash
-set-genre <genre1> <genre2> ...
```

Example:
```bash
dotnet run -set-genre "Rock" "Progressive"
```
### -set-year

Sets the Year tag.
```bash
-set-year <year>
```

Example:
```bash
dotnet run -set-year 2010
```
### -set-composers

Sets the Composers tag.
```bash
-set-composers <composer1> <composer2> ...
```

Example:
```bash
dotnet run -set-composers "Hans Zimmer" "Junkie XL"
```
### -files

Specifies which MP3 files to modify.
```bash
-files <file1.mp3> <file2.mp3> ...
```

Example:
```bash
dotnet run -files song1.mp3 song2.mp3 -set-year 2015 -set-genre Rock
```

This will only edit song1.mp3 and song2.mp3.