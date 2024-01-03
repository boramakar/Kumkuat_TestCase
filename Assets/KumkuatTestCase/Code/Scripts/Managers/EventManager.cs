using System;

public static class EventManager
{
    public static event Action OnSceneTransitionComplete;
    public static void SceneTransitionCompleteEvent()
    {
        OnSceneTransitionComplete?.Invoke();
    }
}