import * as index from './template.handlebars';
import * as classes from './class.handlebars';
import * as interfaces from './interface.handlebars';
import * as schema from './schema.handlebars';
import * as documents from './documents.handlebars';
import * as selectionSet from './selection-set.handlebars';
import * as fragments from './fragments.handlebars';
import * as enumTemplate from './enum.handlebars';
import { EInputType, GeneratorConfig } from 'graphql-codegen-core';
import { getType } from './helpers/get-type';
import { getOptionals } from './helpers/get-optionals';

export const config: GeneratorConfig = {
  inputType: EInputType.SINGLE_FILE,
  templates: {
    index,
    classes,
    interfaces,
    schema,
    documents,
    selectionSet,
    fragments,
    enum: enumTemplate
  },
  flattenTypes: true,
  primitives: {
    String: 'string',
    Int: 'int',
    Float: 'float',
    Boolean: 'bool',
    ID: 'string'
  },
  customHelpers: {
    convertedType: getType,
    getOptionals
  },
  outFile: 'Classes.cs'
};
