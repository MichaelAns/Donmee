namespace Donmee.Client.Validation
{
    /// <summary>
    /// Правило валидации
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value);
    }
}
