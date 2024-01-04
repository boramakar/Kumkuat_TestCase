using System.Linq;
using UnityEngine;

public class AttackListItem : ListItem
{
    #region Serialized-Public-Variables

    [Tooltip("Parent and position marker for PlayerLogoDisplay for Home side.")] [SerializeField]
    private Transform HomeAttackerDisplayParent;

    [Tooltip("Parent and position marker for PlayerLogoDisplay for Away side.")] [SerializeField]
    private Transform AwayAttackerDisplayParent;

    [Tooltip("Reference to AttackButton.")] [SerializeField]
    private AttackButton AttackButton;

    [Tooltip("Reference to AttackSlider.")] [SerializeField]
    private AttackSlider AttackSlider;

    [Tooltip("Reference to SliderPosition marker for when the item is selected or active.")] [SerializeField]
    private Transform SliderPositionMarkerActive;

    [Tooltip("Reference to SliderPosition marker for when the item is unselected and inactive.")] [SerializeField]
    private Transform SliderPositionMarkerInactive;

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

        bool isPrimaryPlayer = IsPrimaryPlayer();
        ChangeLayout(isPrimaryPlayer);
        _isLayoutLocked = isPrimaryPlayer;

        AttackSlider.SetScores(_data.HomeScores.Sum(), _data.AwayScores.Sum());
        GenerateAttackerDisplays();
        FillDisplays(data);
    }

    public override void SetActive()
    {
        if (GameManager.Instance.CurrentSelectedItem != null)
            GameManager.Instance.CurrentSelectedItem.SetInactive();
        GameManager.Instance.CurrentSelectedItem = this;
        
        base.SetActive();
        ChangeLayout(true);
    }

    public override void SetInactive()
    {
        base.SetInactive();
        if (!_isLayoutLocked)
            ChangeLayout(false);
    }

    #endregion

    #region Frontend

    private void ChangeLayout(bool isActive)
    {
        if (isActive)
        {
            AttackButton.Enable(IsPrimaryPlayer());
        }
        else
        {
            AttackButton.Disable();
        }

        AttackSlider.transform.localPosition =
            isActive ? SliderPositionMarkerActive.localPosition : SliderPositionMarkerInactive.localPosition;
    }

    private void GenerateAttackerDisplays()
    {
        Enums.AttackerDisplayType homeAttackerDisplayType =
            _data.HomeSupport == null ? Enums.AttackerDisplayType.Solo : Enums.AttackerDisplayType.Duo;
        Enums.AttackerDisplayType awayAttackerDisplayType =
            _data.AwaySupport == null ? Enums.AttackerDisplayType.Solo : Enums.AttackerDisplayType.DuoInverted;
        _homeAttackerDisplay =
            Instantiate(GameManager.Instance.GameParameters.PrefabData.AttackerDisplays[homeAttackerDisplayType],
                    HomeAttackerDisplayParent.position, Quaternion.identity, HomeAttackerDisplayParent)
                .GetComponent<AttackerDisplay>();
        _awayAttackerDisplay =
            Instantiate(GameManager.Instance.GameParameters.PrefabData.AttackerDisplays[awayAttackerDisplayType],
                    AwayAttackerDisplayParent.position, Quaternion.identity, AwayAttackerDisplayParent)
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

    #region SOLID (?)

    private bool IsPrimaryPlayer()
    {
        GameManager gameManager = GameManager.Instance;
        return _data.HomePlayer.Name == gameManager.PlayerDetails.Name ||
               _data.AwayPlayer.Name == gameManager.PlayerDetails.Name ||
               (_data.HomeSupport != null && _data.HomeSupport.Name == gameManager.PlayerDetails.Name) ||
               (_data.AwaySupport != null && _data.AwaySupport.Name == gameManager.PlayerDetails.Name);
    }

    #endregion
}