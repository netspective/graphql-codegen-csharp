
# CSharp template

Experimental [GraphQL code generator](https://github.com/dotansimha/graphql-code-generator) template for C# projects. 

This template reads the *introspection JSON* of a GraphQL schema as an input. The user has to also mention the output folder where the file has to be written

The name of the output file can be defined in `src/config.ts`

## Requirements

 - [Node](https://nodejs.org/en/download/)
 - [Yarn](https://classic.yarnpkg.com/en/docs/install/#windows-stable)
 
## Usage

For executing the template you can go through the steps below.

Open command prompt and go to working directory and create directory `graphql-code-generator`.

```
 cd graphql-code-generator
 yarn add -D graphql @graphql-codegen/cli  @graphql-codegen/introspection
```

Create a basic `codegen.yml` configuration file, point to your schema like below

```
overwrite: true
schema: "schema path"
generates:
  ./graphql.schema.json:
    plugins:
      - 'introspection'
    config:
      minify: true
```
Then, run the `graphql-codegen` command:

```
yarn graphql-codegen
```
This will generate introspection schema `graphql.schema.json`. This will be used for generating types.

Go to working directory and clone graphql-codegen-csharp in the directory

```
yarn add -D graphql-code-generator@v0.10.3 graphql@0.13.2 graphql-codegen-introspection-template@0.10.3
npm install --save @types/babel-types@7.0.8
cd graphql-codegen-csharp
npm install
```
Execute a `yarn build` from the template folder so that a `dist` folder is created in it.

```
cd ..
yarn gql-gen --schema  ./graphql-code-generator/graphql.schema.json --template graphql-codegen-csharp --out ./
 ```

Other **CLI** Flag options are listed [here](https://github.com/dotansimha/graphql-code-generator#cli-options).
