using TMPro;
using UnityEngine;

public class MatchListItem : ListItem
{
    #region Serialized-Public-Variables

    [Tooltip("Textbox for displaying team name for home team.")] [SerializeField] private TextMeshProUGUI HomeTeamNameTextMesh;
    [Tooltip("Textbox for displaying team name for away team.")] [SerializeField] private TextMeshProUGUI AwayTeamNameTextMesh;
    [Tooltip("Textbox for displaying match time on the button.")] [SerializeField] private TextMeshProUGUI ButtonTextMesh;
    [Tooltip("Textbox for displaying match type.")] [SerializeField] private TextMeshProUGUI MatchTypeTextMesh;
    [Tooltip("Textbox for displaying match date.")] [SerializeField] private TextMeshProUGUI DateTextMesh;
    [Tooltip("Logo display for home team.")] [SerializeField] private LogoDisplay HomeTeamLogoDisplay;
    [Tooltip("Logo display for away team.")] [SerializeField] private LogoDisplay AwayTeamLogoDisplay;

    #endregion

    #region Private-Variables

    private MatchData _matchData;

    #endregion

    #region Frontend

    public override void SetContent(ListItemData data)
    {
        _matchData = data as MatchData;
        if (_matchData == null)
            return;

        HomeTeamNameTextMesh.text = _matchData.HomeTeam.Name;
        AwayTeamNameTextMesh.text = _matchData.AwayTeam.Name;
        ButtonTextMesh.text = _matchData.MatchTime;
        MatchTypeTextMesh.text = nameof(_matchData.MatchType);
        DateTextMesh.text = _matchData.MatchDate;
        HomeTeamLogoDisplay.SetContent(_matchData.HomeTeam.Logo);
        AwayTeamLogoDisplay.SetContent(_matchData.AwayTeam.Logo);
    }

    #endregion

    #region Backend

    public void SetCurrentMatchDetails()
    {
        // This whole method can and should be handled in a better way. I'm a bit too tired to improve this right now.
        if (_matchData == null)
            return;
        GameManager.Instance.CurrentMatchData = _matchData;
    }

    #endregion
}