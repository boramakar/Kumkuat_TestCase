using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI homeScoreText;
    [SerializeField] private TextMeshProUGUI awayScoreText;

    /// <summary>
    /// Sets the numbers on each side of the slider and the slider value based on the scores.
    /// </summary>
    /// <param name="homeScore"> Score to be displayed on the left side of the slider. </param>
    /// <param name="awayScore"> Score to be displayed on the right side of the slider. </param>
    public void SetScores(int homeScore, int awayScore)
    {
        homeScoreText.text = homeScore.ToString();
        awayScoreText.text = awayScore.ToString();
        slider.value = homeScore * 1f / (homeScore + awayScore);
    }
}
