namespace Donmee.Domain.Enums
{
    /// <summary>
    /// Type of a wish
    /// </summary>
    public enum WishType
    {
        /// <summary>
        /// Common wish
        /// </summary>
        Common,

        /// <summary>
        /// Wish, that has some features:
        /// </summary>
        /// <remarks>
        /// - donate only fixed unit of money <br/>
        /// - creates for one day 
        /// </remarks>
        Blitz
    }
}
