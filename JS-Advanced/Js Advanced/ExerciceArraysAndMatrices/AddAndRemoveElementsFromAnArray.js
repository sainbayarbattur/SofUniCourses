function Print(array){

    let arrayToPrint = [];

    for (let index = 0; index < array.length; index++) {
        const element = array[index];

        if (element == 'add') {
            arrayToPrint[index] = index + 1;
        }
        else if(element == 'remove'){
            arrayToPrint.pop();
        }
    }

    if (arrayToPrint.length == 0) {
        console.log('Empty');
        return;
    }

    for (let index = 0; index < arrayToPrint.length; index++) {
        const element = arrayToPrint[index];
        
        if (element === undefined) {
            continue;
        }

        console.log(element);
    }
}

Print(['add', 
'remove',
'remove',
'remove',
'add']
);