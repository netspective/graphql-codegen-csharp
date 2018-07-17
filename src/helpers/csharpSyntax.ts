import { SafeString } from 'handlebars';

export function toCsharpComment(text: String) : SafeString {

    if(text === undefined || text === null || text === ''){
        return new SafeString('');
    }

    return new SafeString("/// <summary>" +  text + '</sumary>');
}