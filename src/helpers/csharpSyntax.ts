import { SafeString } from "handlebars";
import { Variable, Type, Field } from "graphql-codegen-core";

export function eq(text: any, otherText: any): boolean {
    return text === otherText;
}

export function toCsharpComment(text: string): SafeString {
    if(text === undefined || text === null || text === "") {
        return new SafeString("");
    }
    return new SafeString(`/// <summary>${text.replace(/\r?\n|\r/g, " ")}</sumary>`);
}

export function asQueryUnescapedText(text: string): SafeString {

    if(text){
        return new SafeString(text.replace(/&#x3D;/g, "=").replace(/"/g, "\"\""));
    }

    return new SafeString("");
}

export function asArgumentList(variables: Variable[], options: any): string {
    var list: string = "";
    for(let i: number = 0; i < variables.length; i++) {
        var variable: any = variables[i];
        var typeName: string = getType(variable, options) || "object";
        list += `${typeName}  ${variable.name}`;
        if(i < variables.length - 1) {
            list += ",";
        }
    }
    return list;
}

export function getType(type: any, options: any): string {
    if (!type) {
      return "object";
    }
    const baseType: any = type.type;
    const realType: any = options.data.root.primitivesMap[baseType] || baseType;
    if (type.isArray) {
      return `List<${realType}>`;
    } else {
        if(realType === "Long") {
            return "long";
        }
        if(realType === "BigDecimal") {
            return "decimal";
        }
        if(realType === "Float32Bit") {
            return "float";
        }
        if(realType === "LocalTime") {
            return "DateTime";
        }

        if(realType === "URI") {
            return "Uri";
        }

        return realType;
    }
}

export function getOptionals(type: any, options: any): string {
    const config: any = options.data.root.config || {};
    if (
        config.avoidOptionals === "1" ||
        config.avoidOptionals === "true" ||
        config.avoidOptionals === true ||
        config.avoidOptionals === 1
    ) {
        return "";
    }
    if (!type.isRequired) {
        return "";
    }
    return "";
}

export function asJsonString(obj: any): SafeString {
    return new SafeString(JSON.stringify(obj));
}

export function isMutation(typeName: String): Boolean {
    return typeName.lastIndexOf("Mutation") > -1;
}