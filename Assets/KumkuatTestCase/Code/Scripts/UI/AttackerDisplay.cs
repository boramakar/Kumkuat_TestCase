using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackerDisplay : MonoBehaviour
{
    #region Serialized-Public-Variables

    [Tooltip("Logo display for the main attacker.")]
    [SerializeField] private LogoDisplay PrimaryLogoDisplay;
    [Tooltip("Optional. Logo display for the support player if it exists.")]
    [SerializeField] private LogoDisplay SecondaryLogoDisplay;
    [Tooltip("TextMesh used to display the name of the main attacker.")]
    [SerializeField] private TextMeshProUGUI NameDisplay;

    #endregion

    public void SetContent(PlayerData primaryPlayerData, PlayerData secondaryPlayerData = null)
    {
        PrimaryLogoDisplay.SetContent(primaryPlayerData.logo);
        if(SecondaryLogoDisplay != null && secondaryPlayerData != null)
            SecondaryLogoDisplay.SetContent(secondaryPlayerData.logo);
        NameDisplay.text = primaryPlayerData.name;
    }
}
