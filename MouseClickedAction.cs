using Microsoft.Xna.Framework.Input;

namespace InputHandler;

public class MouseClickedAction : IInputAction
{
    private readonly string _btn;

    public MouseClickedAction(string button)
    {
        _btn = button;
    }

    public bool IsTriggered()
    {
        var mouseState = Mouse.GetState();
        
        return _btn switch
        {
            "Left" => Equals(mouseState.LeftButton, ButtonState.Pressed),
            "Right" => Equals(mouseState.RightButton, ButtonState.Pressed),
            "Middle" => Equals(mouseState.RightButton, ButtonState.Pressed),
            _ => false
        };
    }
}
