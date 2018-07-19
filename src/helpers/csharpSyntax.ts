import { SafeString } from 'handlebars';
import { Variable, Type, Field } from 'graphql-codegen-core';

export function eq(text: any, otherText: any) : boolean {
    return text == otherText
}

export function toCsharpComment(text: string) : SafeString {
    if(text === undefined || text === null || text === ''){
        return new SafeString('');
    }
    return new SafeString("/// <summary>" +  text + '</sumary>');
}

export function asQueryUnescapedText(text: string) : SafeString {

    if(text){
        return new SafeString(text.replace('&#x3D;', '='));
    }

    return new SafeString("");
}

export function asArgumentList(variables: Variable[], options) : string {
    var list = '';
    for(let i = 0; i < variables.length; i++){
        var variable = variables[i];
        var typeName = getType(variable, options) || 'object';
        list += `${typeName}  ${variable.name}`;
        if(i < variables.length - 1){
            list += ',';
        }
    }
    return list;
}

export function getType(type, options) {
    if (!type) {
      return '';
    }
    const baseType = type.type;
    const realType = options.data.root.primitivesMap[baseType] || baseType;
    if (type.isArray) {      
      return new SafeString(`List<${realType}>`);
    } 
    else {        
        if(realType === "Long"){
            return "long";
        }
        if(realType === "BigDecimal"){
            return "decimal";
        }
        if(realType === "Float32Bit"){
            return "float";
        }
        if(realType == "LocalTime"){
            return "DateTime";
        }
        return realType;
    }
}

  
export function getOptionals(type, options) {
    const config = options.data.root.config || {};
    if (
        config.avoidOptionals === '1' ||
        config.avoidOptionals === 'true' ||
        config.avoidOptionals === true ||
        config.avoidOptionals === 1
    ) {
        return '';
    }
    if (!type.isRequired) {
        return '';
    }
    return '';
}
  
export function asJsonString(obj) : SafeString {
    return new SafeString(JSON.stringify(obj));
}

export function isMutation(typeName: String) : Boolean {
    return typeName.lastIndexOf('Mutation') > -1;
}