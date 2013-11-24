namespace ps.dmv.common.Lists
{
    /// <summary>
    /// Represents pager item type
    /// </summary>
    public enum PagerItemType
    {
        /// <summary>
        /// Represents an unselected page pager item
        /// </summary>
        Page,
        /// <summary>
        /// Represents a selected page pager item
        /// </summary>
        SelectedPage,
        /// <summary>
        /// Represents a separator (missing pages)
        /// </summary>
        Separator,
        /// <summary>
        /// Represents previous page pager item
        /// </summary>
        Previous,
        /// <summary>
        /// Represents nex page pager item 
        /// </summary>
        Next
    }
}
