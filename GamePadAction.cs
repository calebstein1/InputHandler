using Microsoft.Xna.Framework.Input;

namespace InputHandler;

public class GamePadAction : IInputAction
{
    private readonly Buttons _gpb;
    
    public GamePadAction(Buttons gpb)
    {
        _gpb = gpb;
    }

    public bool IsTriggered()
    {
        return GamePad.GetState(0).IsButtonDown(_gpb);
    }
}
