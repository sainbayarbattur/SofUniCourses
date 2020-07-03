function encodeAndDecodeMessages() {
    const input = document.getElementsByTagName('textarea')[0];
    const output = document.getElementsByTagName('textarea')[1];
    const encodeButton = document.getElementsByTagName('button')[0]
    const decodeButton = document.getElementsByTagName('button')[1]

    encodeButton.addEventListener('click', function(){
        let encodedInput = '';
        for (let i = 0; i < input.value.length; i++) {
            encodedInput += String.fromCharCode(input.value[i].charCodeAt(0) + 1)
        }

        input.value = '';
    
        output.value = encodedInput;
    });

    decodeButton.addEventListener('click', function(){
        let decodedInput = '';
        for (let i = 0; i < output.value.length; i++) {
            decodedInput += String.fromCharCode(output.value[i].charCodeAt(0) - 1)
        }
    
        output.value = decodedInput;
    });
}