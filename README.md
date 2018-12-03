
# CSharp template

Experimental [GraphQL code generator](https://github.com/dotansimha/graphql-code-generator) template for C# projects using instructions provided [at this site](https://github.com/dotansimha/graphql-code-generator/blob/master/packages/templates/README.md). 

This template reads the *introspection JSON* of a GraphQL schema as an input. The user has to also mention the output folder where the file has to be written

The name of the output file can be defined in `src/config.ts`

## Usage

For executing the template, install [**graphql-code-generator**](https://github.com/dotansimha/graphql-code-generator) first. See the install instructions [here](https://github.com/dotansimha/graphql-code-generator#installation) or you can go through the steps below.


Open command prompt and go to working directory.

Execute `yarn add -D graphql-code-generator@v0.10.3 graphql@0.13.2 graphql-codegen-introspection-template@0.10.3`

Clone graphql-codegen-csharp in this directory

```
cd graphql-codegen-csharp

npm install
```
Execute a `yarn build` from the template folder so that a `dist` folder is created in it.

```
cd ..
```
Execute `yarn gql-gen --schema "graphQL schema JSON path" --template graphql-codegen-csharp --out  "output folder path"`.


Other **CLI** Flag options are listed [here](https://github.com/dotansimha/graphql-code-generator#cli-options).
