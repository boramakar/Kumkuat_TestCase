using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteData", menuName = "Kumkuat/SO/Sprite Data", order = 1)]
public class SpriteData : SerializedScriptableObject
{
    [Header("Player Logo")]
    public Sprite[] playerForegroundSprites;
    public Sprite[] playerBackgroundSprites;
    public Sprite[] playerBorderSprites;
    
    [Header("Team Logo")]
    public Sprite[] teamForegroundSprites;
    public Sprite[] teamBackgroundSprites;
    public Sprite[] teamBorderSprites;
}