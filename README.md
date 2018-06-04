---

---

# CSharp template

Experimental [GraphQL code generator](https://github.com/dotansimha/graphql-code-generator) template for C# projects using instructions provided [at this site](https://github.com/dotansimha/graphql-code-generator/blob/master/packages/templates/README.md). This template generates C# code for both client side and server side.

## Generator Config

This generator supports custom config and output behavior. Use to following flags/environment variables to modify your output as you wish:

### `printTime` (or `CODEGEN_PRINT_TIME`, default value: `false`)

Setting this to true will cause the generator to add the time of the generated output on top of the file.

This template reads the `introspection JSON` of a graphQL schema as an input. User has to also mention the `output folder` where the file has to be written.

The name of the output file can be defined in `src/config.ts`

## Usage

For executing the template, install [**graphql-code-generator**](https://github.com/dotansimha/graphql-code-generator) first.

Then, we will be able to execute the template as well.

Install and Build the template using `yarn build` command and run the below command.

`gql-gen --schema "graphQL schema JSON" --template "path of the template file" --out "output folder path"`

Other **Cli** Flag options are listed below : 

| Flag Name           | Type     | Description                                                  |
| ------------------- | -------- | ------------------------------------------------------------ |
| s,--schema          | String   | Local or remote path to GraphQL schema: Introspection JSON file, GraphQL server endpoint to fetch the introspection from, local file that exports `GraphQLSchema`, JSON object or AST string. |
| -r,--require        | String   | Path to a `require` extension, [read this](https://gist.github.com/jamestalmage/df922691475cff66c7e6) for more info |
| -h,--header         | String   | Header to add to the introspection HTTP request when using remote endpoint |
| -t,--template       | String   | Template name, for example: "typescript" (not required when using `--project`) |
| -p,--project        | String   | Project directory with templates (refer to "Custom Templates" section) |
| --project-config    | String   | Path to project config JSON file (refer to "Custom Templates" section), defaults to `gqlgen.json` |
| -o,--out            | String   | Path for output file/directory. When using single-file generator specify filename, and when using multiple-files generator specify a directory |
| -m,--skip-schema    | void     | If specified, server side schema won't be generated through the template (enums won't omit) |
| -c,--skip-documents | void     | If specified, client side documents won't be generated through the template |
| --no-overwrite      | void     | If specified, the generator will not override existing files |
| documents...        | [String] | Space separated paths of `.graphql` files or code files (glob path is supported) that contains GraphQL documents inside strings, or with either `gql` or `graphql` tag (JavaScript), this field is optional - if no documents specified, only server side schema types will be generated |

