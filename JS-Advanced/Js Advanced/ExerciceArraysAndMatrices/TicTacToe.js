function TickTacToe(array){

    var board = [[false, false, false],
                [false, false, false],
                [false, false, false]];

    let players = ['O', 'X'];

    for (let index = 0; index < array.length; index++) {
        
        let string = array[index].split(' ');

        let point = {x:string[0], y:string[1]}

        let currPlayer = '';

        if (NotFalse(board)) {
            break;
        }

        if (board[point.x][point.y] == false) {

            let last = players.pop();
            players.unshift(last);
            currPlayer = players[0];
            board[point.x][point.y] = currPlayer;
        }
        else{

            console.log("This place is already taken. Please choose another!");
            continue;
        }

        let winnerCheck = Check(board, currPlayer);

        if (winnerCheck) {

            console.log('Player ' + currPlayer + ' wins!');
            Print(board);
            return;
        }
    }

    console.log('The game ended! Nobody wins :(');

    Print(board);

    function Check(matrix, player){

        let allLine = true;

        // horizon

        for (let r = 0; r < 3; r++) {
            
            allLine = true;

            for (let c = 0; c < 3; c++) {

                if (matrix[r][c] == player) {
                    allLine = true;
                }
                else{

                    allLine = false;
                    break;
                }
            }

            if (allLine) {
                break;
            }
        }

        if (allLine) {

            return allLine;
        }

        // vertical

        for (let c = 0; c < 3; c++) {
            
            allLine = true;

            for (let r = 0; r < 3; r++) {

                if (matrix[r][c] == player) {
                    allLine = true;
                }
                else{

                    allLine = false;
                    break;
                }
            }

            if (allLine) {
                break;
            }
        }

        if (allLine) {

            return allLine;
        }

        //diagonal

        for (let rc = 0; rc < 3; rc++) {

            allLine = true;

            if (matrix[rc][rc] != player) {
                allLine = false;
                break;
            }
        }

        if (allLine) {

            return allLine;
        }

        //0 1 0
        //1 0 1
        //0 1 0

        for (let rc = 0; rc < 3 ; rc++) {

            allLine = true;

            if (matrix[Math.abs(rc - 2)][rc] != player) {
                allLine = false;
                break;
            }
        }

        return allLine;
    }

    function Print(matrix){

        for (let r = 0; r < matrix.length; r++) {

            console.log(matrix[r].join('\t'));
        }
    }

    function NotFalse(matrix){

        let isTrue = false;

        for (let r = 0; r < 3; r++) {

            for (let c = 0; c < 3; c++) {

                if (matrix[r][c] == 'X' || matrix[r][c] == 'O') {

                    isTrue = true;
                }
                else{
                    isTrue = false;
                    break;
                }
                
            }

            if (!isTrue) {
                break;
            }
            
        }

        return isTrue;
    }
}

TickTacToe(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]);