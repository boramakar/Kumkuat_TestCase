using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Kumkuat/Dummy/Dummy Lists", fileName = "DummyLists", order = 0)]
public class DummyLists : SerializedScriptableObject
{
    public AttackData[] attackList;
    public MatchData[] matchList;
    public PlayerData[] playerList;
    public TeamData[] teamList;
}