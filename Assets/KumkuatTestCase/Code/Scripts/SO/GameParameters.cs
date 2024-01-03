using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Kumkuat/SO/Game Parameters", fileName = "GameParameters", order = 0)]
public class GameParameters : SerializedScriptableObject
{
    public float fadeDuration = 0.1f;
    public ColorData ColorData;
    public SpriteData SpriteData;
    public PrefabData PrefabData;
}