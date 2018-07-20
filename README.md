# CSharp Generator for Queries

We forked @netspective 's (Thanks dude!) project and changed it so the templates emit only the query objects and models. In our case it is better to work off the queries than having a query builder. 

# Goals

- [x] Generate C# Query classes for Queries and Mutations
- [x] Generate C# Models for Query return types 
- [ ] Emit multiple files
- [ ] Full integration testing of the CSharp code against a dokerized GraphQL server
- [ ] Type converters for `LocalDate` and some excotic Scala scalar types we have

# CSharp template

Experimental [GraphQL code generator](https://github.com/dotansimha/graphql-code-generator) template for C# projects using instructions provided [at this site](https://github.com/dotansimha/graphql-code-generator/blob/master/packages/templates/README.md). 

This template reads the *introspection JSON* of a GraphQL schema as an input. The user has to also mention the output folder where the file has to be written

The name of the output file can be defined in `src/config.ts`

## Usage

For executing the template, install [**graphql-code-generator**](https://github.com/dotansimha/graphql-code-generator) first. See the install instructions [here](https://github.com/dotansimha/graphql-code-generator#installation).

Once we install graphql-code-generator, clone this project into your workspace.

After cloning the project, we can either install or build the template to function the graphql code generator.

Install the template using `npm install` command from the project folder path.

`npm install -g`

After installing the template, run the following command to generate the c# code from the graphql schema.

`gql-gen --schema "graphQL schema JSON path" --template "graphql-codegen-csharp" --out "output folder path"`

 You can either build the template using `yarn build` command and run the following command to run the generator.

`gql-gen --schema "graphQL schema JSON" --template "path of the template file" --out "output folder path"`

Other **Cli** Flag options are listed [here](https://github.com/dotansimha/graphql-code-generator#cli-options).

Once the C# code got generated, add the file into class library project in Visual Studio.

Build the project and check if any type errors are there.

## Examples

### Queries

* `dummy.graphql` https://gist.github.com/jenol/a07b2fe602c8bb0c9b7aefe89f745eae.js
* `update.graphql` https://gist.github.com/jenol/d20df6609ae44e7fb64674f17a5622c1

### Output 

* `Classes.cs` https://gist.github.com/jenol/6346f2b5a6d5397495aba7734c01e0ea

The Query objects can be called with a http client for example: 

```
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
```

```
var client = new GraphqlClient("http://bk-qaycsa-1001/v2/graphql");
var result = await client.ExecuteAsync(new Generated.MyQuery.Query(1));
```


