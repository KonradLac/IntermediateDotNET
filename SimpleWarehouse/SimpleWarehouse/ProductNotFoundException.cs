namespace SimpleWarehouse
{
    internal class ProductNotFoundException : ArgumentException
    {
        public ProductNotFoundException(string message) : base(message)
        {
        }

        public ProductNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override string ToString()
        {
            return $"ProductNotFoundException: {Message}";
        }
    }
}
