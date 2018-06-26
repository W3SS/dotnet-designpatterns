namespace ContactManager.Core
{
    public class OnlineOrderProcessor : IOrderProcessor, IOnlineOrderProcessor
    {
        public void ProcessOrder(Order order)
        {
            // do something with order
        }

        public bool ValidateCardInfo(CardInfo cardInfo)
        {
            // validate credit card information
            return true;
        }

        public bool ValidateShippingAddress(Address address)
        {
            // validate shipping destination
            return true;
        }
    }
}
