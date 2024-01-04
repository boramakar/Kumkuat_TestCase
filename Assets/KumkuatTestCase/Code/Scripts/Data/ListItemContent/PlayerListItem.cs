using TMPro;
using UnityEngine;

public class PlayerListItem : ListItem
{
    #region Serialized-Public-Variables

    [Tooltip("Textbox for displaying player name.")] [SerializeField] private TextMeshProUGUI NameTextMesh;
    [Tooltip("Textbox for displaying player level.")] [SerializeField] private TextMeshProUGUI LevelTextMesh;
    [Tooltip("Textbox for displaying player goal count.")] [SerializeField] private TextMeshProUGUI GoalCountTextMesh;
    [Tooltip("Logo display for the player.")] [SerializeField] private LogoDisplay PlayerLogoDisplay;

    #endregion
    public override void SetContent(ListItemData data)
    {
        PlayerData playerData = data as PlayerData;
        if (playerData == null)
            return;
        
        PlayerLogoDisplay.SetContent(playerData.Logo);
        NameTextMesh.text = playerData.Name;
        LevelTextMesh.text = playerData.Level.ToString();
        GoalCountTextMesh.text = playerData.Goals.ToString();
    }
}