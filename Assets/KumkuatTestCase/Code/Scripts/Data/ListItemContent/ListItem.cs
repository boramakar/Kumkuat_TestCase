using UnityEngine;
using UnityEngine.UI;

public abstract class ListItem : MonoBehaviour, IListItem
{
    [Tooltip("Reference to BackgroundImage.")]
    [SerializeField] protected Image backgroundImage;
    [Tooltip("Reference to HighlightImage.")]
    [SerializeField] protected Image highlightImage;

    #region IListItem

    public abstract void SetContent(ListItemData data);

    public virtual GameObject GetGameObject()
    {
        return gameObject;
    }

    public virtual void SetBackgroundColor(Enums.ListItemBackgroundColorType backgroundColorType)
    {
        backgroundImage.color =
            GameManager.Instance.GameParameters.ColorData.ListItemBackgroundColors[backgroundColorType];
    }
    
    public virtual void ToggleSelect(bool isSelected)
    {
        highlightImage.enabled = isSelected;
    }

    #endregion
}