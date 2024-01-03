using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Kumkuat/SO/Prefab Data", fileName = "PrefabData", order = 3)]
public class PrefabData : SerializedScriptableObject
{
    public Dictionary<Enums.AttackerDisplayType, GameObject> AttackerDisplays;
    // TODO: Dictionary for list item prefabs
}
