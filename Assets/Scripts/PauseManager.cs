using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : IPauseHandler
{
    private List<IPauseHandler> _handlers = new List<IPauseHandler>();

    public bool IsPaused { get; private set; }

    public void Register(IPauseHandler handler)
    {
        _handlers.Add(handler);
    }

    public void UnRegister(IPauseHandler handler)
    {
        _handlers.Remove(handler);
    }

    public void setPause(bool isPaused)
    {
        IsPaused = isPaused;
        foreach (var handler in _handlers)
        {
            handler.setPause(isPaused);
        }
    }
}
