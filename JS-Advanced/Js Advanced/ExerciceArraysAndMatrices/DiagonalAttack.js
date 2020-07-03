function Print(matrix){

    let rowLenght = matrix.length;

    var newMatrix = [];
    for (let r = 0; r < matrix.length; r++) {

        let string = matrix[r].split(' ').map(m => Number(m));

        newMatrix.push(string);
    }

    let firstDiagSum = 0;

    let secondDiagSum = 0;

    let firstPoints = [{x:0, y:0}]

    let secondPoints = [{x:0, y:0}]

    for (let rc = 0; rc < rowLenght; rc++) {

        firstPoints[rc] = {x:0, y:0};
        firstPoints[rc].x = rc;
        firstPoints[rc].y = rc;
        firstDiagSum += newMatrix[rc][rc];
    }

    for (let rc = 0; rc < rowLenght ; rc++) {

        secondPoints[rc] = {x:0, y:0};
        secondPoints[rc].x = Math.abs(rc - (rowLenght - 1));
        secondPoints[rc].y = rc;

        secondDiagSum += newMatrix[Math.abs(rc - (rowLenght - 1))][rc];
    }

    if (firstDiagSum + secondDiagSum) {
        
        ChangeMatrix(newMatrix, firstPoints, secondPoints, firstDiagSum);
    }

    PrintMatrix(newMatrix);

    function ChangeMatrix(array, firstP, secondP, sum){

        for (let r = 0; r < array.length; r++) {
            
            for (let c = 0; c < array.length; c++) {
                
                let contains = false;

                for (let i = 0; i < firstP.length; i++) {
                 
                    if ((firstP[i].x == r && firstP[i].y == c) || (secondP[i].x == r && secondP[i].y == c)) {

                        contains = true;
                        break;
                    }
                }

                if (!contains) {
                    array[r][c] = sum;
                }
            }
        }
    }

    function PrintMatrix(matrix){

        let string = '';

        for (let r = 0; r < matrix.length; r++) {

            for (let c = 0; c < matrix[0].length; c++) {
             
                string += matrix[r][c] + ' ';
            }

            string += '\n';
        }

        console.log(string);
    }
}

Print(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']
);