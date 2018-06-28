namespace MvcDesignPattern.Core
{
    public class CashOnDeliveryOrderProcessor : IOrderProcessor
    {
        public void ProcessOrder(Order order)
        {
            // do something with order
        }

        public bool ValidateShippingAddress(Address address)
        {
            // validate shipping destination
            return true;
        }
    }
}
