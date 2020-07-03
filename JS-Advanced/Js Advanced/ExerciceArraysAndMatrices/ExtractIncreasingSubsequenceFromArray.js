function Print(array){

    let arrayToPrint = [array[0]];

    let count = 0;

    for (let index = 1; index < array.length; index++) {
        const element = array[index];

        if (arrayToPrint[count] <= element) {

            count++;

            arrayToPrint[count] = element;
        }
        
    }

    for (let index = 0; index < arrayToPrint.length; index++) {
        const element = arrayToPrint[index];

        console.log(element);
        
    }
}

Print([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
    );