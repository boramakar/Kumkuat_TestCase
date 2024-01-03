public interface IScrollList
{
    /// <summary>
    /// Generate list items using the data provided in listItems.
    /// </summary>
    /// <param name="listItems">Data for all items to be added to the list sorted from top to bottom.</param>
    public void SetContents(ListItemData[] listItems);
    
    /// <summary>
    /// Destroy all items belonging to this list.
    /// </summary>
    public void Clear();
}
