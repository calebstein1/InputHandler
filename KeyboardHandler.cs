using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace MonoGameCross_PlatformDesktopApplication1;

public class KeyboardHandler
{
    private readonly Dictionary<string, List<Keys>> _keyMap = new()
    {
        { "Up", new List<Keys>{ Keys.W, Keys.Up } },
        { "Down", new List<Keys>{ Keys.S, Keys.Down } },
        { "Left", new List<Keys>{ Keys.A, Keys.Left } },
        { "Right", new List<Keys>{ Keys.D, Keys.Right } },
        { "Dash", new List<Keys>{ Keys.LeftShift, Keys.RightShift } },
        { "PrimaryAction", new List<Keys>{ Keys.Space } },
        { "SecondaryAction", new List<Keys>{ Keys.LeftControl, Keys.RightControl} },
    };

    public bool Action(string keyAction)
    {
        return _keyMap.TryGetValue(keyAction, out var keys) && keys.Any(k => Keyboard.GetState().IsKeyDown(k));
    }

    public string GetAction()
    {
        return _keyMap.Keys.FirstOrDefault(a =>
                _keyMap[a].Any(k =>
                    Keyboard.GetState().IsKeyDown(k)));
    }
}
