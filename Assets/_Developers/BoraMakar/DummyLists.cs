using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Kumkuat/Dummy/Dummy Lists", fileName = "DummyLists", order = 0)]
public class DummyLists : SerializedScriptableObject
{
    public AttackData[] AttackList;
    public MatchData[] MatchList;
    public PlayerData[] PlayerList;
    public TeamData[] TeamList;
}