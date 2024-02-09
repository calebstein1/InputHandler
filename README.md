# MonoGame Keyboard Handler

This is a very basic keyboard event handler for the MonoGame framework.
It allows you to map multiple keys to a single event using a dictionary mapping event names to a list of keys.

## Configuration 

You can reference this project in your game project, or just copy KeyboardHandler.cs into your project and make sure the namespace is updated accordingly.
Then, as can be seen in the example configuration, you'll just add dictionary entries containing your event name as a string and a list of keys that map to that event as a new `List<Keys>`.

## Usage

First, you'll need to initialize a new KeyboardHandler object with a keymap, which is a `Dictionary<string, List<Keys>>`.
Here's an example keymap and initialization:
```csharp
private readonly Dictionary<string, List<Keys>> KeyMap = new()
{
    { "Up", new List<Keys>{ Keys.W, Keys.Up } },
    { "Down", new List<Keys>{ Keys.S, Keys.Down } },
    { "Left", new List<Keys>{ Keys.A, Keys.Left } },
    { "Right", new List<Keys>{ Keys.D, Keys.Right } },
    { "Dash", new List<Keys>{ Keys.LeftShift, Keys.RightShift } },
    { "PrimaryAction", new List<Keys>{ Keys.Space } },
    { "SecondaryAction", new List<Keys>{ Keys.LeftControl, Keys.RightControl} },
};

private readonly KeyboardHandler _keyboardHandler;

public Game1()
{
    _keyboardHandler = new Keyboardhandler(KeyMap);
    // Other constructor code...
}
```
Then there are two methods by which you can use this library in your game loop: IsActionPressed(string keyAction) and GetPressedAction().

#### IsActionPressed(string keyAction)

The Action method takes the name of a defined action as a parameter and will return a boolean depending on whether or not a mapped key for that action is currently being pressed.
```csharp
if (_keyboardHandler.IsActionPressed("Right"))
    Player.MoveRight();
else if (_keyboardHandler.IsActionPressed("Left"))
    Player.MoveLeft();
```

#### GetPressedAction()

The GetAction method returns as a string the name of the action associated with the currently pressed key.
```csharp
switch (_keyboardHandler.GetPressedAction())
{
    case "Right":
        Player.MoveRight();
        break;
    case "Left":
        Player.MoveLeft();
        break;
}
```
