using System.Threading.Tasks;

namespace Sealbreaker
{
    public interface ISealBreakerClient
    {
        /// <summary>
        /// Gets a value from Azure Key Vault with a certain key
        /// </summary>
        /// <param name="key">The specific key you want the value of.</param>
        /// <returns>The value of the specific key.</returns>
        /// <remarks>If in development mode, the key itself is returned as value.</remarks>
        Task<string> GetSecretValue(string key);
        /// <summary>
        /// Encrypt data with Azure Key vault keys
        /// </summary>
        /// <param name="keyIdentifier">The key inside your vault</param>
        /// <param name="data">Data you want to encrypt</param>
        /// <returns>Encrypted Data</returns>
        Task<byte[]> Encrypt(string keyIdentifier, byte[] data);
        /// <summary>
        /// Decrypt data with Azure Key vault keys
        /// </summary>
        /// <param name="keyIdentifier">The key inside your vault</param>
        /// <param name="data">Data you want to decrypt</param>
        /// <returns>Decrypted Data</returns>
        Task<byte[]> Decrypt(string keyIdentifier, byte[] data);
    }
}
