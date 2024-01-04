using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class TeamData : ListItemData
{
    public string Name = "Team";
    public LogoData Logo;
    [Range(1, 10000)] public int Level = 1;
    [Range(1, 22)] public int MemberCount = 1;
}