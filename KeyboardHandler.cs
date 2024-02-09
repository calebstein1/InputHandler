using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace KeyboardHandler;

public class KeyboardHandler
{
    private readonly Dictionary<string, List<Keys>> _keyMap;

    public KeyboardHandler(Dictionary<string, List<Keys>> keyMap)
    {
        _keyMap = keyMap;
    }

    public bool IsActionPressed(string keyAction)
    {
        var currentState = Keyboard.GetState();
        return _keyMap.TryGetValue(keyAction, out var keys) && keys.Any(k => currentState.IsKeyDown(k));
    }

    public string GetPressedAction()
    {
        var currentState = Keyboard.GetState();
        return _keyMap.Keys.FirstOrDefault(a =>
                _keyMap[a].Any(k =>
                    currentState.IsKeyDown(k)));
    }
}
