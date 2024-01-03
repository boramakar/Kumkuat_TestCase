using System.Linq;
using UnityEngine;

public class AttackListItem : ListItem
{
    #region Serialized-Public-Variables

    [Tooltip("Parent and position marker for PlayerLogoDisplay for Home side.")]
    [SerializeField] private Transform homeAttackerDisplayParent;
    [Tooltip("Parent and position marker for PlayerLogoDisplay for Away side.")]
    [SerializeField] private Transform awayAttackerDisplayParent;
    [Tooltip("Reference to AttackButton.")]
    [SerializeField] private AttackButton attackButton;
    [Tooltip("Reference to AttackSlider.")]
    [SerializeField] private AttackSlider attackSlider;
    [Tooltip("Reference to SliderPosition marker for when the item is selected or active.")]
    [SerializeField] private Transform sliderPositionMarkerActive;
    [Tooltip("Reference to SliderPosition marker for when the item is unselected and inactive.")]
    [SerializeField] private Transform sliderPositionMarkerInactive;

    #endregion

    #region Private-Variables

    private AttackerDisplay _homeAttackerDisplay;
    private AttackerDisplay _awayAttackerDisplay;
    private AttackData _data;
    private bool _isLayoutLocked;

    #endregion

    #region IListItem-Methods

    public override void SetContent(ListItemData data)
    {
        _data = data as AttackData;
        // This null check should be replaced with proper error handling for a real scenario.
        if (_data == null)
            return;

        _isLayoutLocked = IsPrimaryPlayer();
        attackSlider.SetScores(_data.HomeScores.Sum(), _data.AwayScores.Sum());
        GenerateAttackerDisplays();
        FillDisplays(data);
    }

    public override void ToggleSelect(bool isSelected)
    {
        base.ToggleSelect(isSelected);
        if (!_isLayoutLocked)
            ChangeLayout(isSelected);
    }

    #endregion

    #region Frontend

    private void ChangeLayout(bool isActive)
    {
        attackButton.Enable(isActive);
        attackSlider.transform.localPosition =
            isActive ? sliderPositionMarkerActive.localPosition : sliderPositionMarkerInactive.localPosition;
    }

    private void GenerateAttackerDisplays()
    {
        Enums.AttackerDisplayType homeAttackerDisplayType =
            _data.HomeSupport == null ? Enums.AttackerDisplayType.Solo : Enums.AttackerDisplayType.Duo;
        Enums.AttackerDisplayType awayAttackerDisplayType =
            _data.AwaySupport == null ? Enums.AttackerDisplayType.Solo : Enums.AttackerDisplayType.DuoInverted;
        _homeAttackerDisplay =
            Instantiate(GameManager.Instance.GameParameters.PrefabData.AttackerDisplays[homeAttackerDisplayType],
                    homeAttackerDisplayParent.position, Quaternion.identity, homeAttackerDisplayParent)
                .GetComponent<AttackerDisplay>();
        _awayAttackerDisplay =
            Instantiate(GameManager.Instance.GameParameters.PrefabData.AttackerDisplays[awayAttackerDisplayType],
                    awayAttackerDisplayParent.position, Quaternion.identity, awayAttackerDisplayParent)
                .GetComponent<AttackerDisplay>();
    }

    private void FillDisplays(ListItemData data)
    {
        AttackData attackData = data as AttackData;
        // Could be improved to provide better error handling or the system could be checked to ensure this value is never null
        if (attackData == null)
            return;
        _homeAttackerDisplay.SetContent(attackData.HomePlayer, attackData.HomeSupport);
        _awayAttackerDisplay.SetContent(attackData.AwayPlayer, attackData.AwaySupport);
    }

    #endregion

    #region Encapsulation

    private bool IsPrimaryPlayer()
    {
        GameManager gameManager = GameManager.Instance;
        return _data.HomePlayer.name == gameManager.playerDetails.name ||
               _data.AwayPlayer.name == gameManager.playerDetails.name ||
               (_data.HomeSupport != null && _data.HomeSupport.name == gameManager.playerDetails.name) ||
               (_data.AwaySupport != null && _data.AwaySupport.name == gameManager.playerDetails.name);
    }

    #endregion
}