using System;
using UnityEngine;

[Serializable]
public class PlayerData : ListItemData
{
    public string Name = "Player";
    public LogoData Logo;
    [Range(1, 10000)] public int Level = 1;
    [Range(0, 10000)] public int Goals = 0;
}