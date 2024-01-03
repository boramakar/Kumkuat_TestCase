using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoDisplay : MonoBehaviour
{
    #region Serliazed-Public-Variables

    [SerializeField] private Image maskImage;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image foregroundImage;
    [SerializeField] private Image borderImage;

    #endregion
    
    public void SetContent(LogoData logoData)
    {
        Sprite[] playerLogo = LogoManager.Instance.GetPlayerLogo(logoData.backgroundIndex, logoData.foregroundIndex, logoData.borderIndex);
        foregroundImage.sprite = playerLogo[0];
        backgroundImage.sprite = playerLogo[1];
        borderImage.sprite = playerLogo[2];
        maskImage.sprite = playerLogo[2];
    }
}
