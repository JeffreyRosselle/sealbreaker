using System.Threading.Tasks;
using Sealbreaker.Types;

namespace Sealbreaker
{
    public class SealBreakerClient : ISealBreakerClient
    {
        private readonly IAuthenticationType _authenicationClient;
        private readonly bool _isDevelopment = false;

        /// <summary>
        /// Creates a client in release mode with AppAuthenication.
        /// </summary>
        public SealBreakerClient()
        {
            _isDevelopment = false;
            _authenicationClient = new AppAuthenticationClient();
        }

        /// <summary>
        /// Creates a client with AppAuthentication.
        /// </summary>
        /// <param name="isDevelopment">Specify if development mode should be used.</param>
        public SealBreakerClient(bool isDevelopment = false)
        {
            _isDevelopment = isDevelopment;
            if (!isDevelopment)
                _authenicationClient = new AppAuthenticationClient();
        }

        /// <summary>
        /// Gets a value from Azure Key Vault with a certain key
        /// </summary>
        /// <param name="key">The specific key you want the value of.</param>
        /// <returns>The value of the specific key.</returns>
        /// <remarks>If in development mode, the key itself is returned as value.</remarks>
        public async Task<string> GetSecretValue(string key) =>
            _isDevelopment ? key : await _authenicationClient.GetSecretValue(key);

        /// <summary>
        /// Encrypt data with Azure Key vault keys
        /// </summary>
        /// <param name="keyIdentifier">The key inside your vault</param>
        /// <param name="data">Data you want to encrypt</param>
        /// <returns>Encrypted Data</returns>
        public async Task<byte[]> Encrypt(string keyIdentifier, byte[] data) =>
            _isDevelopment ? data : await _authenicationClient.Encrypt(keyIdentifier, data);

        /// <summary>
        /// Decrypt data with Azure Key vault keys
        /// </summary>
        /// <param name="keyIdentifier">The key inside your vault</param>
        /// <param name="data">Data you want to decrypt</param>
        /// <returns>Decrypted Data</returns>
        public async Task<byte[]> Decrypt(string keyIdentifier, byte[] data) =>
            _isDevelopment ? data : await _authenicationClient.Decrypt(keyIdentifier, data);
    }
}