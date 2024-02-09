# MonoGame Keyboard Handler

This is a very basic keyboard event handler for the MonoGame framework.
It allows you to map multiple keys to a single event using a dictionary mapping event names to a list of keys.

## Configuration 

You can reference this project in your game project, or just copy KeyboardHandler.cs into your project and make sure the namespace is updated accordingly.
Then, as can be seen in the example configuration, you'll just add dictionary entries containing your event name as a string and a list of keys that map to that event as a new `List<Keys>`.

## Usage

There are two methods by which you can use this library in your game loop: Action(string keyAction) and GetAction().

#### Action(string keyAction)

The Action method takes the name of a defined action as a parameter and will return a boolean depending on whether or not a mapped key for that action is currently being pressed.
```
var keyboardHandler = new KeyboardHandler();

if (keyboardHandler.Action("Right"))
    Player.MoveRight();
else if (keyboardHandler.Action("Left"))
    Player.MoveLeft();
```

#### GetAction()

The GetAction method returns as a string the name of the action associated with the currently pressed key.
```
var keyboardHandler = new KeyboardHandler();

switch (keyboardHandler.GetAction())
{
    case "Right":
        Player.MoveRight();
        break;
    case "Left":
        Player.MoveLeft();
        break;
}
```
