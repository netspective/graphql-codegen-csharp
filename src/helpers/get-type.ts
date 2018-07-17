import { SafeString } from 'handlebars';

export function getType(type, options) {
  if (!type) {
    return '';
  }

  // Get Type based on Array Type and Normal Class or object Type.
  const baseType = type.type;
  const realType = options.data.root.primitivesMap[baseType] || baseType;
  const useImmutable = !!(options.data.root.config || {}).immutableTypes;

  if (type.isArray) {
    let result = realType;
    result = `List<${result}>`;
    return new SafeString(result);
  } else {
    
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
