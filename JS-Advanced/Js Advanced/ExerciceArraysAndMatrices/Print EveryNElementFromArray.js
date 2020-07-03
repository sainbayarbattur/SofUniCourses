function Print(array){

    let lastNumber = Number(array[array.length - 1]);

    for (let index = 0; index < array.length - 1; index+=lastNumber) {
        const element = array[index];
        
        console.log(element);

    }
}