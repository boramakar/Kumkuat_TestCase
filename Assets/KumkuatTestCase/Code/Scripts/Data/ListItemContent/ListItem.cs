using UnityEngine;
using UnityEngine.UI;

public abstract class ListItem : MonoBehaviour, IListItem
{
    #region Serialized-Public-Variables

    [Tooltip("Reference to BackgroundImage.")] [SerializeField]
    protected Image BackgroundImage;

    [Tooltip("Reference to HighlightImage.")] [SerializeField]
    protected Image HighlightImage;

    #endregion

    #region IListItem

    public abstract void SetContent(ListItemData data);

    public virtual GameObject GetGameObject()
    {
        return gameObject;
    }

    public virtual void SetBackgroundColor(Enums.ListItemBackgroundColorType backgroundColorType)
    {
        BackgroundImage.color =
            GameManager.Instance.GameParameters.ColorData.ListItemBackgroundColors[backgroundColorType];
    }

    public virtual void SetActive()
    {
        HighlightImage.enabled = true;
    }

    public virtual void SetInactive()
    {
        HighlightImage.enabled = false;
    }

    #endregion
}