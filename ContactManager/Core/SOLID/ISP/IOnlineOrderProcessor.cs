namespace ContactManager.Core
{
    public interface IOnlineOrderProcessor
    {
        bool ValidateCardInfo(CardInfo cardInfo);
    }
}
