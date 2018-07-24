using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Generated;

namespace OutTest
{
    public class GraphqlClient
    {
        private const string _contentType = "application/json"; // "application/graphql";
        private static readonly HttpClient _client = new HttpClient();

        private readonly string _graphQlUrl;

        public GraphqlClient(string graphQlUrl)
        {
            _graphQlUrl = graphQlUrl;
        }

        public async Task<T> ExecuteAsync<T>(IQuery<T> query)
        {
            var json = query.GetQueryText();

            var response = await _client.PostAsync(_graphQlUrl, new StringContent(json, Encoding.UTF8, _contentType));

            var responseString = await response.Content.ReadAsStringAsync();

            return query.GetParsedObject(responseString);
        }
    }
}
