using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoDisplay : MonoBehaviour
{
    #region Serliazed-Public-Variables

    [SerializeField] private Image MaskImage;
    [SerializeField] private Image BackgroundImage;
    [SerializeField] private Image ForegroundImage;
    [SerializeField] private Image BorderImage;

    #endregion

    #region Frontend

    public void SetContent(LogoData logoData)
    {
        Sprite[] playerLogo = LogoManager.Instance.GetPlayerLogo(logoData.backgroundIndex, logoData.foregroundIndex, logoData.borderIndex);
        ForegroundImage.sprite = playerLogo[0];
        BackgroundImage.sprite = playerLogo[1];
        BorderImage.sprite = playerLogo[2];
        MaskImage.sprite = playerLogo[2];
    }

    #endregion
}
