namespace ContactManager.Core
{
    public interface IOrderProcessor
    {
        bool ValidateShippingAddress(Address address);
        void ProcessOrder(Order order);
    }
}
