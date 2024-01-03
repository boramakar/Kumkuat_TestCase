using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    #region Serialized-Public-Variables

    [SerializeField] private TextMeshProUGUI textMesh;

    #endregion

    public void Enable(bool isPrimaryAttacker)
    {
        // TODO: Turn this into DOTween animation
        transform.localScale = Vector3.one;
        textMesh.text = isPrimaryAttacker ? nameof(Enums.AttackerRole.Attack) : nameof(Enums.AttackerRole.Assist);
    }

    public void Disable()
    {
        // TODO: Turn this into DOTween animation
        transform.localScale = Vector3.zero;
    }
    
    public void OnClick()
    {
        
    }
}
