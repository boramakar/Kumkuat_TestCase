using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Kumkuat/SO/Game Parameters", fileName = "GameParameters", order = 0)]
public class GameParameters : SerializedScriptableObject
{
    [FoldoutGroup("Animation")] public float FadeDuration = 0.25f;
    [FoldoutGroup("Animation")] public float DefaultAnimationDuration = 0.25f;
    
    [FoldoutGroup("Data")] public ColorData ColorData;
    [FoldoutGroup("Data")] public SpriteData SpriteData;
    [FoldoutGroup("Data")] public PrefabData PrefabData;
}