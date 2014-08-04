using System;
using System.Text;

namespace DigestAuthDemo.Http
{
    public class DigestHeader
    {
        public static DigestHeader Create(string header, string method)
        {
            var digestHeader = new DigestHeader { Method = method };
            var keyValuePairs = header.Replace("\"", String.Empty);

            foreach (var keyValuePair in keyValuePairs.Split(','))
            {
                var index = keyValuePair.IndexOf("=", StringComparison.InvariantCulture);
                if (index < 0)
                    continue;

                var key = keyValuePair.Substring(0, index).Trim();
                var value = keyValuePair.Substring(index + 1).Trim();

                switch (key)
                {
                    case "username":
                        digestHeader.UserName = value;
                        break;
                    case "realm":
                        digestHeader.Realm = value;
                        break;
                    case "nonce":
                        digestHeader.Nonce = value;
                        break;
                    case "uri":
                        digestHeader.Uri = value;
                        break;
                    case "nc":
                        digestHeader.NounceCounter = value;
                        break;
                    case "cnonce":
                        digestHeader.Cnonce = value;
                        break;
                    case "response":
                        digestHeader.Response = value;
                        break;
                    case "method":
                        digestHeader.Method = value;
                        break;
                }
            }

            return digestHeader;
        }

        public static DigestHeader Unauthorized(string realm)
        {
            return new DigestHeader
            {
                Realm = "realm",
                Nonce = DigestNonce.Generate()
            };
        }

        private DigestHeader() { }
        
        public string Cnonce { get; private set; }
        public string Nonce { get; private set; }
        public string Realm { get; private set; }
        public string UserName { get; private set; }
        public string Uri { get; private set; }
        public string Response { get; private set; }
        public string Method { get; private set; }
        public string NounceCounter { get; private set; }

        public override string ToString()
        {
            var header = new StringBuilder();
            header.AppendFormat("realm=\"{0}\"", Realm);
            header.AppendFormat(", nonce=\"{0}\"", Nonce);
            header.AppendFormat(", qop=\"{0}\"", "auth");
            return header.ToString();
        }
    }
}