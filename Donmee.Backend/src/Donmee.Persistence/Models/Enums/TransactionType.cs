namespace Donmee.Persistence.Models.Enums
{
    /// <summary>
    /// Type of a transaction
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Creating of a transaction
        /// </summary>
        Creating = 0,

        /// <summary>
        /// User's donate to anybody
        /// </summary>
        Donate = 1,

        /// <summary>
        /// Replenishment of the balance
        /// </summary>
        Replenishment = 2
    }
}
