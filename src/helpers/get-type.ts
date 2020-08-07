import { SafeString } from 'handlebars';

export function getType(type, options) {
  if (!type) {
    return '';
  }

  // Get Type based on Array Type and Normal Class or object Type.
  const baseType = type.type;
  const realType = options.data.root.primitivesMap[baseType] || baseType;
  const useImmutable = !!(options.data.root.config || {}).immutableTypes;
  const isInterface = (type.isInterface) ? 'I':'';
  if (type.isArray) {
    let result = realType;
    result = `List<${isInterface}${result}>`;
    return new SafeString(result);
  } else {
    return `${isInterface}${realType}`;
  }
}
