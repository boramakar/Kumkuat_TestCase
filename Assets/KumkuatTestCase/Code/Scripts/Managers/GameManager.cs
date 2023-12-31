﻿using HappyTroll;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    public GameParameters GameParameters;

    // These are for testing purposes. In a real implementation these data should come from a server.

    #region Dummy-Variables

    public PlayerData PlayerDetails;
    public DummyLists DummyLists;
    [HideInInspector] public ListItem CurrentSelectedItem;
    [HideInInspector] public MatchData CurrentMatchData;

    #endregion

    #region LifeCycle

    private void Start()
    {
        TransitionManager.Instance.ChangeScene(Enums.SceneType.MatchList);
    }

    #endregion
}