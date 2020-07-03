function Print(first, second){

    let row = first;

    let col = second;

    let point = {x:0, y:0};

    let number = first * second;

    let sum = 0;

    let matrix = [];

    let i = 0;

    for (let r = 0; r < row; r++) {
        
        matrix.push([]);

        for (let c = 0; c < col; c++) {
            
            matrix[r][c] = 0;
        }
    }

    while (sum != number) {

        //right

        point.y++;

        if (i == col - i - 1) {

            matrix[point.x][point.y] = ++sum;
            continue;
        }

        for (let c = i; c < col - i - 1; c++) {
            
            point.y = c;

            sum++;

            matrix[point.x][point.y] = sum;
        }

        point.y++;

        //down

        for (let r = i; r < row - i - 1; r++) {
            
            point.x = r;

            sum++;

            matrix[point.x][point.y] = sum;
        }

        point.x++;

        //left

        for (let c = col - i - 1; c > i; c--) {
            
            point.y = c;

            sum++;

            matrix[point.x][point.y] = sum;
        }

        point.y--;

        //up

        for (let r = row - i - 1; r > i ; r--) {
            
            point.x = r;

            sum++;

            matrix[point.x][point.y] = sum;
        }

        i++;
    }

    PrintMatrix(matrix);

    function PrintMatrix(matrix){

        for (let r = 0; r < matrix.length; r++) {
        
            console.log(matrix[r].join(' '));
        }
    }
}

Print(5, 5);