using System.Threading.Tasks;

namespace Sealbreaker
{
    public interface ISealBreakerClient
    {
        Task<string> GetSecretValue(string key);
        Task<byte[]> Encrypt(string keyIdentifier, byte[] data);
        Task<byte[]> Decrypt(string keyIdentifier, byte[] data);
    }
}
