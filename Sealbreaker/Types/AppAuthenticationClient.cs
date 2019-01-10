using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System.Threading.Tasks;

namespace Sealbreaker.Types
{
    internal class AppAuthenticationClient : IAuthenticationType
    {
        private readonly KeyVaultClient _keyVaultClient;

        public AppAuthenticationClient() =>
            _keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(new AzureServiceTokenProvider().KeyVaultTokenCallback));

        public async Task<byte[]> Encrypt(string keyIdentifier, byte[] data) =>
            (await _keyVaultClient.EncryptAsync(keyIdentifier, "RSA-OAEP", data)).Result;

        public async Task<byte[]> Decrypt(string keyIdentifier, byte[] data) =>
            (await _keyVaultClient.DecryptAsync(keyIdentifier, "RSA-OAEP", data)).Result;

        public async Task<string> GetSecretValue(string key) =>
            (await _keyVaultClient.GetSecretAsync(key)).Value;

    }
}
