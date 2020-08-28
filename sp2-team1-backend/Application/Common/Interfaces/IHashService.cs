
namespace Application.Common.Interfaces
{
    public interface IHashService
    {
        string GetHash(string input);
        bool Verify(string candidate, string hashed);
    }
}
