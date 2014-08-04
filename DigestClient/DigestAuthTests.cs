using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace DigestClient
{
    public class DigestAuthTests
    {
        [Fact]
        public void DigestCredentials()
        {
            var requestUri = new Uri("http://localhost/DigestAuthDemo/");

            var credCache = new CredentialCache
            {
                {
                    new Uri("http://localhost/"), 
                    "Digest", 
                    new NetworkCredential("Test", "Test", "/")
                }
            };

            using (var clientHander = new HttpClientHandler
            {
                Credentials = credCache,
                PreAuthenticate = true
            })
            using (var httpClient = new HttpClient(clientHander))
            {
                for (var i = 0; i < 5; i++)
                {
                    var responseTask = httpClient.GetAsync(requestUri);
                    responseTask.Result.EnsureSuccessStatusCode();
                }
            }
        }
    }
}
