# DiscordProgrammingLessons

At first lesson we wrote the code below and some refactored.

```C#
Console.CursorVisible = false;

var maze = new[]
{
	"#",
	".",
	".",
	".",
	".",
	".",
	".",
	".",
	".",
	"#"
};

var positionX = 1;

while (true)
{
	foreach (string pixel in maze)
	{
		Console.Write(pixel);
	}

	Console.WriteLine();

	ConsoleKeyInfo keyInfo = Console.ReadKey(true);
	if (keyInfo.Key == ConsoleKey.D)
	{
		maze[positionX] = ".";
		positionX++;
		maze[positionX] = ((char) 1).ToString();
	}
	else if (keyInfo.Key == ConsoleKey.Q)
	{
		Console.Write("\nGame Over!");
		break;
	}
	else if (keyInfo.Key == ConsoleKey.A)
	{
		maze[positionX] = ".";
		positionX--;
		maze[positionX] = ((char) 1).ToString();
	}

	Console.Clear();
}
```
