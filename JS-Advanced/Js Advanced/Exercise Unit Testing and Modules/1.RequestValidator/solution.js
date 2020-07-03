function main(obj){
    let methodValidation = obj.method === 'GET' || obj.method === 'POST'|| obj.method === 'DELETE'|| obj.method === 'CONNECT'
    let uriValidation = RegExp('^[A-Za-z0-9.]+$').test(obj.uri);
    let versionValidation = obj.version === 'HTTP/2.0' || obj.version === 'HTTP/1.1' || obj.version === 'HTTP/1.0' || obj.version === 'HTTP/0.9'

    let messageValidation = true;

    if (obj.method === undefined || !methodValidation) {
        throw new Error("Invalid request header: Invalid Method");
    }

    if (obj.uri === undefined || !uriValidation) {
        throw new Error("Invalid request header: Invalid URI");
    }

    if (obj.version === undefined || !versionValidation ) {
        throw new Error("Invalid request header: Invalid Version");
    }
    
    if (obj.message === undefined) {
        throw Error("Invalid request header: Invalid Message");
    }

    for (let i = 0; i < obj.message.length; i++) {
        const element = obj.message[i];

        if (['<', '>', '\\', '&', "'", '"'].includes(element)) {
            messageValidation = false;
            break;
        }
        
    }

    if (obj.message === undefined || (!messageValidation && obj.message != '')) {
        throw Error("Invalid request header: Invalid Message");
    }

    if (methodValidation && uriValidation && versionValidation && (messageValidation || obj.message === '')) {
        return obj;
    }
}

main({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1'
})