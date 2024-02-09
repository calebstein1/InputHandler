# MonoGame Input Handler

This is a basic input handler for the MonoGame framework.
Unlike other input handler libraries out there, this one is action based.
It allows you to map any number of inputs to a named action, and then to use those named actions in your logic rather than having to refer to specific inputs.

## Configuration 

You can reference this project in your game project, or just copy all of the .cs files into your project and make sure the namespaces are updated accordingly.
Then, as can be seen in the example configuration below, you'll just add dictionary entries containing your action name as a string and a list of inputs that map to that action as a new `List<IInputAction>`.

## Usage

First, you'll need to initialize a new InputHandler object with an InputMap, which is a `Dictionary<string, List<IInputAction>>`.
Here's an example inputmap and initialization:
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
Then there are a few methods by which you can use this library in your game loop: InputByActionMap, IsActionTriggered, GetTriggeredAction.

#### InputByActionMap

This is the preferred method to define what happens on each action.
You'll  need to create an ActionMap, which is a `Dictionary<string, Action>`, and pass that into the `InputByActionMap` function.
Here's an example setup using an ActionMap:
```csharp
var actionMap = new Dictionary<string, Action>
{
    { "Up", () => Player.MoveUp() },
    { "Down", () => Player.MoveDown() },
    { "Left", () => Player.MoveLeft() },
    { "Right", () => Player.MoveRight() },
    { "PrimaryAction", () => Player.PrimaryAction() },
    { "SecondaryAction", () => Player.SecondaryAction() }
};

_inputHandler.InputByActionMap(actionMap);
```
This setup allows for ActionMaps to be defined on instances of objects as well as per scene or level, and allows for easy context-based switching of ActionMaps by simply changes which map is passed into the InputByActionMap method.
The less-refined IsActionTriggered and GetTriggeredAction methods are still suppored and do have their use cases, but ActionMaps are the generally perferred solution for defining what happens on each input.

#### IsActionTriggered

The IsActionTriggered method takes the name of a defined action as a parameter and will return a boolean depending on whether or not a mapped input for that action is currently being pressed.
```csharp
if (_inputHandler.IsActionTriggered("Right"))
    Player.MoveRight();
if (_inputHandler.IsActionTriggered("Left"))
    Player.MoveLeft();
```

#### GetTriggeredAction

The GetTriggeredAction method returns as a string the name of the action associated with the currently triggered input.
This doesn't work all that well at the moment, as it simply returns the name of the first action it detects, so it doesn't work reliably when multiple actions are triggered at once.
This will likely be updated to return a List<string> of each currently triggered action.
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

## What's next?

Getting a proper Vector2 from the gamepad control sticks for movement is pretty necessary.
Control stick movement just feels weird right now without that.
Top priority to fix.

After that, saving and loading inputmaps to and from files in a serialized format would be nice.
The current dictionary approach is pretty unwieldy and the whole thing would be much cleaner as JSON or YAML or basically anything else combined with a bit of logic to assemble the dictionary at runtime or new InputHandler initialization.
