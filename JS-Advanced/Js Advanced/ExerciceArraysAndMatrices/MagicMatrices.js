function Check(matrix){

    let number = 0;

    const reducer = (accumulator, currentValue) => accumulator + currentValue;

    for (let r = 0; r < matrix.length - 1; r++) {

        number = matrix[r].reduce(reducer)

        if (number != matrix[r + 1].reduce(reducer)) {
            console.log(false);
            return;
        }
    }

    number = 0;

    let array = [];

    for (let c = 0; c < matrix.length; c++) {

        for (let r = 0; r < matrix.length; r++) {

            if (matrix[r][c] != undefined) {
                number += matrix[r][c];     
            } 
        }

        array[c] = number;

        number = 0;

        let a = array[c] - array[c - 1];

        if (array.length >= 2 && a) {
            console.log(false);
            return;
        }
    }

    console.log(true);
}