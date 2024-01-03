using HappyTroll;

public class GameManager : PersistentSingleton<GameManager>
{
    public GameParameters GameParameters;

    // These are for testing purposes. In a real implementation these data should come from a server.

    #region Dummy-Variables

    public PlayerData playerDetails;
    public DummyLists dummyLists;

    #endregion

    #region LifeCycle

    private void Start()
    {
        TransitionManager.Instance.ChangeScene(Enums.SceneType.MatchDetails);
    }

    #endregion
}