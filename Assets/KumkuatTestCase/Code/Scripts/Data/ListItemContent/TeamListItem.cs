using TMPro;
using UnityEngine;

public class TeamListItem : ListItem
{
    #region Serialized-Public-Variables

    [Tooltip("Textbox for displaying team name.")] [SerializeField] private TextMeshProUGUI NameTextMesh;
    [Tooltip("Textbox for displaying team level.")] [SerializeField] private TextMeshProUGUI LevelTextMesh;
    [Tooltip("Textbox for displaying team member count.")] [SerializeField] private TextMeshProUGUI MemberCountTextMesh;
    [Tooltip("Logo display for the team.")] [SerializeField] private LogoDisplay TeamLogoDisplay;

    #endregion
    public override void SetContent(ListItemData data)
    {
        TeamData teamData = data as TeamData;
        if (teamData == null)
            return;
        
        TeamLogoDisplay.SetContent(teamData.Logo);
        NameTextMesh.text = teamData.Name;
        LevelTextMesh.text = teamData.Level.ToString();
        MemberCountTextMesh.text = teamData.MemberCount.ToString();
    }
}