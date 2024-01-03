using System.Collections.Generic;
using UnityEngine;


public class LogoManager : PersistentSingleton<LogoManager>
{
    #region Private-Variables
    
    private const int PLAYER_LOGO_LAYER_COUNT = 3;

    #endregion

    #region Public-Methods

    /// <summary>
    /// Returns all sprites needed to create a player logo in order of Foreground, Background and Border
    /// </summary>
    /// <param name="foregroundIndex"></param>
    /// <param name="backgroundIndex"></param>
    /// <param name="borderIndex"></param>
    /// <returns></returns>
    public Sprite[] GetPlayerLogo(int backgroundIndex = 0, int foregroundIndex = 0, int borderIndex = 0)
    {
        SpriteData spriteLists = GameManager.Instance.GameParameters.SpriteData;
        return new Sprite[PLAYER_LOGO_LAYER_COUNT]
        {
            spriteLists.playerBackgroundSprites[backgroundIndex],
            spriteLists.playerForegroundSprites[foregroundIndex],
            spriteLists.playerBorderSprites[borderIndex]
        };
    }

    /// <summary>
    /// Returns all sprites needed to create a team logo in order of Foreground, Background and Border
    /// </summary>
    /// <param name="foregroundIndex"></param>
    /// <param name="backgroundIndex"></param>
    /// <param name="borderIndex"></param>
    /// <returns></returns>
    public Sprite[] GetTeamLogo(int foregroundIndex = 0, int backgroundIndex = 0, int borderIndex = 0)
    {
        SpriteData spriteLists = GameManager.Instance.GameParameters.SpriteData;
        return new Sprite[PLAYER_LOGO_LAYER_COUNT]
        {
            spriteLists.teamBackgroundSprites[backgroundIndex],
            spriteLists.teamForegroundSprites[foregroundIndex],
            spriteLists.teamBorderSprites[borderIndex]
        };
    }

    #endregion
}