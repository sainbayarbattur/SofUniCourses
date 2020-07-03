function Print(array){

    let arrayToPrint = [];

    for (let index = 0; index < array.length; index++) {

        let string  = array[index].split(' / ');

        let name = string[0];

        let level = Number(string[1]);
    
        let items = [];

        if (string.length > 2) {
         
            items = string[2].split(', ')
        }

        let object = {"name": name, "level": level, "items": items};

        arrayToPrint[index] = object;
    }

    return JSON.stringify(arrayToPrint);
}

console.log(Print(['Jake / 1000']));