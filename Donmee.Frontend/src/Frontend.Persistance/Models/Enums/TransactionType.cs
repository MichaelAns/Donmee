namespace Frontend.Persistance.Models.Enums
{
    /// <summary>
    /// Type of a transaction
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Creating of a transaction
        /// </summary>
        Creating,

        /// <summary>
        /// User's donate to anybody
        /// </summary>
        Donate,

        /// <summary>
        /// Replenishment of the balance
        /// </summary>
        Replenishment
    }
}
