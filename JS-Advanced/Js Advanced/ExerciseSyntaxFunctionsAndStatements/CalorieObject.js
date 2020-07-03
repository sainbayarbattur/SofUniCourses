function Print(array){

    let string = '';

    for (let index = 0; index < array.length - 1; index+=2) {

        string += array[index] + ': ';
        if (index == array.length - 2) {
            string += array[index + 1]; 
        }
        else{
            string += array[index + 1] + ', '; 
        }
    }

    console.log('{ ' + string + ' }');
}

console.log(Print(['Yoghurt', 48, 'Rise', 138, 'Apple', 52]));