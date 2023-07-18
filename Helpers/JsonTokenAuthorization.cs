using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace WorkflowBddFramework.Helpers
{
    public class JsonTokenAuthorization : AuthenticatorBase
    {
        private readonly string _baseUrl;
        private readonly string _client;
        private readonly string _password;
        private readonly string _scope;

        public JsonTokenAuthorization(string baseUrl, string client, string password, string scope) : base("")
        {
            _baseUrl = baseUrl;
            _client = client;
            _password = password;
            _scope = scope;
        }

        protected override ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
        {
            Token = string.IsNullOrEmpty(Token) ? GetToken() : Token;
            return new ValueTask<Parameter>(new HeaderParameter(KnownHeaders.Authorization, Token));
        }

        public string GetToken()
        {
            var options = new RestClientOptions(_baseUrl);
            {
                options.Authenticator = new HttpBasicAuthenticator(_client, _password);
            }

            var client = new RestClient(options);

            {
                var request = new RestRequest("", Method.Post);
                request.AddHeader("Authorization", "Basic " + options);
                request.AddParameter("grant_type", "client_credentials");
                request.AddParameter("scope", _scope);
                var tokenresponse = client.Execute(request).Content;
                var jsonResponse = JObject.Parse(tokenresponse);
                tokenresponse = (string)jsonResponse["access_token"];

                return $"Bearer {tokenresponse}";
            }
        }
    }
}
