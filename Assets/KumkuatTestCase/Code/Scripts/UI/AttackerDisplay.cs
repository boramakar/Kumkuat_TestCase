using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackerDisplay : MonoBehaviour
{
    #region Serialized-Public-Variables

    [SerializeField] private LogoDisplay primaryLogoDisplay;
    [SerializeField] private LogoDisplay secondaryLogoDisplay;
    [SerializeField] private TextMeshProUGUI nameDisplay;

    #endregion

    public void SetContent(PlayerData primaryPlayerData, PlayerData secondaryPlayerData = null)
    {
        primaryLogoDisplay.SetContent(primaryPlayerData.logo);
        if(secondaryLogoDisplay != null && secondaryPlayerData != null)
            secondaryLogoDisplay.SetContent(secondaryPlayerData.logo);
        nameDisplay.text = name;
    }
}
