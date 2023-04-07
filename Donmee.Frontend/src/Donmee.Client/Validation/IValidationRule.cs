namespace Donmee.Client.Validation
{
    public interface IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value);
    }
}
