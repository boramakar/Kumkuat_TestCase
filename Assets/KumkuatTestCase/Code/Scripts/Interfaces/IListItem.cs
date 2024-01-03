using UnityEngine;

public interface IListItem
{
    /// <summary>
    /// Sets the content of the item based on the data.
    /// </summary>
    /// <param name="data">Data to be used to fill the contents of the list item.</param>
    public void SetContent(ListItemData data);
    
    /// <summary>
    /// Sets the background color of this item to be light or dark.
    /// </summary>
    /// <param name="backgroundColorTypeType">Can be light or dark.
    /// Used to create an alternating pattern to make it easier to differentiate list items from each other.</param>
    public void SetBackgroundColor(Enums.ListItemBackgroundColorType backgroundColorTypeType);
    
    /// <summary>
    /// Returns the game object this script is attached to.
    /// </summary>
    /// <returns>Returns the game object this script is attached to.</returns>
    public GameObject GetGameObject();

    /// <summary>
    /// Toggles the item state between active and inactive.
    ///
    /// Used to define highlight state and perform other changes as necessary.
    /// </summary>
    /// <param name="isSelected">True for active. False for inactive.</param>
    public void ToggleSelect(bool isSelected);
}
