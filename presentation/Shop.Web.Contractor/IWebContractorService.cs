namespace Shop.Web.Contractor
{
    public interface IWebContractorService
    {
        string UniqueCode { get; }

        string GetUri { get; }
    }
}