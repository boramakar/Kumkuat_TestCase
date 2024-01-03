using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDataProvider : MonoBehaviour
{
    [SerializeField] private ScrollList list;
    [SerializeField] private Enums.ListType listType;

    #region LifeCycle

    private void Start()
    {
        // Safety precaution in case there is something left over inside content during development
        list.Clear();
        switch (listType)
        {
            case Enums.ListType.Attack:
                list.SetContents(GameManager.Instance.DummyLists.AttackList);
                break;
            case Enums.ListType.Match:
                list.SetContents(GameManager.Instance.DummyLists.MatchList);
                break;
            case Enums.ListType.Team:
                list.SetContents(GameManager.Instance.DummyLists.TeamList);
                break;
            case Enums.ListType.Player:
                list.SetContents(GameManager.Instance.DummyLists.PlayerList);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #endregion
}
