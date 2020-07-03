function Print(array){

    let stringToPrint = '';

    for (let index = 0; index < array.length - 1; index++) {
        const element = array[index];

        if (index < array.length - 2) {
            stringToPrint += element + array[array.length - 1];
        } else {
            stringToPrint += element;
        }
    }

    console.log(stringToPrint);
}
