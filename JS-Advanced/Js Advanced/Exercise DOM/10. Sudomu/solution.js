function solve() {
    let matrix = document.getElementsByTagName('tbody')[0].children;
    let table = document.getElementsByTagName('table')[0];

    //clear
    document.getElementsByTagName('button')[1].addEventListener('click', function(){
        for (let r = 0; r < matrix.length; r++) {
            for (let c = 0; c < matrix[r].children.length; c++) {
                matrix[r].children[c].children[0].value = '';
            }
        }

        document.getElementById('check').children[0].textContent = "";
        table.style.border = "none";
    });

    //check
    document.getElementsByTagName('button')[0].addEventListener('click', function(){
        let newMatrix = [];

        for (let i = 0; i < matrix.length; i++) {
            newMatrix[i] = [];
            for (let b = 0; b < matrix[i].children.length; b++) {
                newMatrix[i][b] = matrix[i].children[b].children[0].value;
            }
        }

        let isValid = true;
        for (let c = 0; c < newMatrix.length; c++) {
            if (!check(newMatrix[c])) {
                isValid = false;
            }

            if (!isValid) {
                notDoneYet();
                return;
            }
        }

        for (let r = 0; r < newMatrix.length; r++) {

            let col = [];
            for (let c = 0; c < newMatrix[r].length; c++) {
                col[c] = newMatrix[c][r];
            }

            if (!check(col)) {
                notDoneYet();
                return;
            }
        }

        if (isValid) {
            done();   
        }
    });

    function notDoneYet(){
        document.getElementById('check').children[0].innerHTML = "NOP! You are not done yet...";
        document.getElementById('check').children[0].style.color = "red";
        table.style.border = "2px solid red";
    }

    function done(){
        document.getElementById('check').children[0].innerHTML = "You solve it! Congratulations!";
        document.getElementById('check').children[0].style.color = "green";
        table.style.border = "2px solid green";
    }

    function check(array){
        return array.filter((e, i) => array.indexOf(e) === i).length === array.length;
    }
}