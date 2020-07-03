function Orbit(array){

    let rowLength = array[0];

    let colLength = array[1];

    let matrix = [];

     let point = {x:array[2], y:array[3]}

    for (let r = 0; r < rowLength; r++) {
        
        matrix.push([]);

        for (let c = 0; c < colLength; c++) {

            matrix[r][c] = Math.max(Math.abs(point.x - r),Math.abs(point.y - c)) + 1   
        }
    }

    for (let r = 0; r < matrix.length; r++) {
        
        console.log(matrix[r].join(' '));
    }
}

Orbit([4, 4, 0, 0]);