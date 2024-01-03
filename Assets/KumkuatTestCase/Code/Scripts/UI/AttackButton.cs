using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    #region Serialized-Public-Variables

    [SerializeField] private TextMeshProUGUI TextMesh;

    #endregion

    #region Frontend (?)

    public void Enable(bool isPrimaryAttacker)
    {
        // TODO: Turn this into DOTween animation
        transform.DOScale(Vector3.one, GameManager.Instance.GameParameters.DefaultAnimationDuration);
        TextMesh.text = isPrimaryAttacker ? nameof(Enums.AttackerRole.Attack) : nameof(Enums.AttackerRole.Assist);
    }

    public void Disable()
    {
        // TODO: Turn this into DOTween animation
        transform.localScale = Vector3.zero;
    }
    
    public void OnClick()
    {
        // Not implemented, outside the scope of this test case
    }

    #endregion
}
