namespace Donmee.Client.Validation.Rules
{
    internal class IsNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value) =>
            value is string str &&
            !string.IsNullOrWhiteSpace(str);
    }
}
