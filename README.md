# MonoGame Input Handler

This is a basic input event handler for the MonoGame framework.
It allows you to map multiple inputs to a single event using a dictionary mapping event names to a list of inputs.

## Configuration 

You can reference this project in your game project, or just copy all of the .cs files into your project and make sure the namespace is updated accordingly.
Then, as can be seen in the example configuration, you'll just add dictionary entries containing your event name as a string and a list of inputs that map to that event as a new `List<IInputAction>`.

## Usage

First, you'll need to initialize a new InputHandler object with a keymap, which is a `Dictionary<string, List<IInputAction>>`.
Here's an example keymap and initialization:
```csharp
private readonly Dictionary<string, List<IInputAction>> _inputMap = new()
{
    { "Up", new List<IInputAction> { new KeyboardAction(Keys.W), new KeyboardAction(Keys.Up), new GamePadAction(Buttons.LeftThumbstickUp) } },
    { "Down", new List<IInputAction> { new KeyboardAction(Keys.S), new KeyboardAction(Keys.Down), new GamePadAction(Buttons.LeftThumbstickDown) } },
    { "Left", new List<IInputAction> { new KeyboardAction(Keys.A), new KeyboardAction(Keys.Left), new GamePadAction(Buttons.LeftThumbstickLeft) } },
    { "Right", new List<IInputAction> { new KeyboardAction(Keys.D), new KeyboardAction(Keys.Right), new GamePadAction(Buttons.LeftThumbstickRight) } },
    { "Dash", new List<IInputAction> { new KeyboardAction(Keys.LeftShift), new KeyboardAction(Keys.RightShift), new GamePadAction(Buttons.LeftTrigger) } },
    { "PrimaryAction", new List<IInputAction> { new KeyboardAction(Keys.Space), new MouseClickedAction("Left"), new GamePadAction(Buttons.A) } },
    { "SecondaryAction", new List<IInputAction> { new KeyboardAction(Keys.LeftControl), new KeyboardAction(Keys.RightControl), new MouseClickedAction("Right"), new GamePadAction(Buttons.RightTrigger) } },
};

private readonly InputHandler _inputHandler;

public Game1()
{
    _inputHandler = new InputHandler(_inputMap);
    // Other constructor code...
}
```
Then there are two methods by which you can use this library in your game loop: IsActionTriggered(string keyAction) and GetTriggeredAction().

#### IsActionPressed(string keyAction)

The Action method takes the name of a defined action as a parameter and will return a boolean depending on whether or not a mapped key for that action is currently being pressed.
```csharp
if (_inputHandler.IsActionTriggered("Right"))
    Player.MoveRight();
else if (_inputHandler.IsActionTriggered("Left"))
    Player.MoveLeft();
```

#### GetTriggeredAction()

The GetAction method returns as a string the name of the action associated with the currently pressed key.
```csharp
switch (_inputHandler.GetTriggeredAction())
{
    case "Right":
        Player.MoveRight();
        break;
    case "Left":
        Player.MoveLeft();
        break;
}
```
