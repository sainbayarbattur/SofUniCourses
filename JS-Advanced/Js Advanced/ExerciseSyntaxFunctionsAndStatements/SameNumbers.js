function Check(number){

    let numberToString = String(number);

    let string = numberToString;

    let isTrue = true;
    
    for (let index = 0; index < string.length - 1; index++) {

        if (string[index] != string[index + 1]) {
            isTrue = false;
            break;
        }
        else{
            isTrue = true;
        }
    };

    if (isTrue) {
        console.log(true);
    }
    else{
        console.log(false);
    }   

    let sum = 0;

    for (let index = 0; index < string.length; index++) {

        sum += Number(string[index]);
    }

    console.log(sum);
}