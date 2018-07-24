using System;
using Newtonsoft.Json;

namespace OutTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new GraphqlClient("http://bk-qaycsa-1001/v2/graphql");

            var result = client.ExecuteAsync(new Generated.MyQuery.Query("some", "stuff")).Result;

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            Console.WriteLine(json);

            Console.ReadLine();
        }
    }
}
