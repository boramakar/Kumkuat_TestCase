using System;

[Serializable]
public class Enums
{
    public enum SceneType
    {
        SplashScene = 0,
        LoadingScene = 1,
        MatchList = 2,
        MatchDetails = 3,
        TeamList = 4,
        TeamDetails = 5
    }

    public enum MatchType
    {
        None,
        League,
        Cup
    }

    public enum AttackerDisplayType
    {
        None,
        Solo,
        Duo,
        DuoInverted
    }

    public enum AttackerRole
    {
        Attack,
        Assist
    }

    public enum ListItemBackgroundColorType
    {
        Light,
        Dark
    }
    
    public enum ListType
    {
        Attack,
        Match,
        Team,
        Player
    }
}