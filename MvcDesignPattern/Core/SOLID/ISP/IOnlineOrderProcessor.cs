namespace MvcDesignPattern.Core
{
    public interface IOnlineOrderProcessor
    {
        bool ValidateCardInfo(CardInfo cardInfo);
    }
}
