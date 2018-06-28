namespace MvcDesignPattern.Core
{
    public class Order
    {
        public int OrderId { get; set; }
        public Address ShippingAddress { get; set; }
        public CardInfo CardInfo { get; set; }
    }
}