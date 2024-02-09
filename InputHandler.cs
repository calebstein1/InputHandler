using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InputHandler;

public class InputHandler
{
    private readonly Dictionary<string, List<IInputAction>> _inputMap;

    public InputHandler(Dictionary<string, List<IInputAction>> inputMap)
    {
        _inputMap = inputMap;
    }

    public bool IsActionTriggered(string inputAction)
    {
        return _inputMap.TryGetValue(inputAction, out var input) &&
               input.Any(i => i.IsTriggered());
    }

    public string GetTriggeredAction()
    {
        return _inputMap.Keys.FirstOrDefault(a =>
                _inputMap[a].Any(k =>
                    k.IsTriggered()));
    }

    public void InputByActionMap(Dictionary<string, Action> actionMap)
    {
        foreach (var kvp in actionMap.Where(kvp =>
                     IsActionTriggered(kvp.Key)))
        {
            kvp.Value.Invoke();
        }
    }
}
