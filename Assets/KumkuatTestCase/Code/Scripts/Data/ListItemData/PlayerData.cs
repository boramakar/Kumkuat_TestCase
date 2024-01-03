using System;
using UnityEngine;

[Serializable]
public class PlayerData : ListItemData
{
    public string name = "Player";
    public LogoData logo;
    [Range(1, 10000)] public int level = 1;
    [Range(0, 10000)] public int goals = 0;
}