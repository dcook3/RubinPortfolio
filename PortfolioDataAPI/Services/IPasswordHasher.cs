namespace RubinPortfolio.Services
{
    public interface IPasswordHasher
    {
        public string GetHash(string pass);
    }
}
