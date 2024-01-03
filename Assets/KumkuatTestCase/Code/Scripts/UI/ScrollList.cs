using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class ScrollList : SerializedMonoBehaviour, IScrollList
{
    #region Serialized-Public-Variables

    [Tooltip("Reference to content of scroll view.")]
    [SerializeField] private Transform contentParent;
    [Tooltip("Prefab to be used to fill the list.")]
    [SerializeField] private IListItem listItem;

    #endregion

    #region Private-Variables

    private float _listItemHeight;
    private float _listItemWidth;
    private GameObject _listItemPrefab;

    #endregion

    #region LifeCycle

    private void Awake()
    {
        _listItemPrefab = listItem.GetGameObject();
        _listItemHeight = _listItemPrefab.GetComponent<RectTransform>().rect.height;
        _listItemWidth = contentParent.GetComponent<RectTransform>().rect.width;
    }

    #endregion

    #region IScrollList-Methods
    
    public void SetContents(ListItemData[] listItems)
    {
        // Set size of the content area to be exactly as large as the total height of all items
        contentParent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, listItems.Length * _listItemHeight);
        
        for (int index = 0; index < listItems.Length; index++)
        {
            // Contents of this method can be moved here from methods to reduce overhead
            GameObject element = GenerateListItem(index);
            SetContent(listItems[index], element, index);
        }
    }

    // Exists in case we want to refill the list without changing scenes
    public void Clear()
    {
        for (int index = contentParent.childCount - 1; index >= 0; index--)
        {
            Destroy(contentParent.GetChild(index));
        }
    }

    #endregion

    #region Frontend
    
    private GameObject GenerateListItem(int index)
    {
        GameObject element = Instantiate(listItem.GetGameObject(), Vector3.zero, Quaternion.identity, contentParent);
        RectTransform rectTransform = element.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(_listItemWidth / 2f, (index + .5f) * -_listItemHeight, 0);
        return element;
    }

    private static void SetContent(ListItemData listItem, GameObject element, int index)
    {
        IListItem currentListItem = element.GetComponent<IListItem>();
        currentListItem.SetContent(listItem);
        currentListItem.SetBackgroundColor(index % 2 == 0
            ? Enums.ListItemBackgroundColorType.Light
            : Enums.ListItemBackgroundColorType.Dark);
    }

    #endregion
}