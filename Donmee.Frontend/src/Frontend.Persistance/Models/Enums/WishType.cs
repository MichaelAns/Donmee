namespace Frontend.Persistance.Models.Enums
{
    /// <summary>
    /// Type of a wish
    /// </summary>
    public enum WishType
    {
        /// <summary>
        /// Common wishe
        /// </summary>
        Common,

        /// <summary>
        /// Wish, that has some features:
        /// </summary>
        /// <remarks>
        /// - donate only one unit of money
        /// - creates for one day 
        /// </remarks>
        Blitz
    }
}
