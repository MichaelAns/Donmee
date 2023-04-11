namespace Donmee.Client.Validation.Rules
{
    internal class IsIntOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value) =>
            value is int number &&
                number > 0;
    }
}
