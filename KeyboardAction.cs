using Microsoft.Xna.Framework.Input;

namespace InputHandler;

public class KeyboardAction: IInputAction
{
    private readonly Keys _key;

    public KeyboardAction(Keys key)
    {
        _key = key;
    }

    public bool IsTriggered()
    {
        return Keyboard.GetState().IsKeyDown(_key);
    }
}
