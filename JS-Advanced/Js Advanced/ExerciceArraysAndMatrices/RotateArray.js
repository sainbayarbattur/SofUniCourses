function Shift(array){

    let last = Number(array.pop());

    if (last > 1000) {

        last = last % 1000;
    }

    for (let index = 0; index < last ; index++) {

        let currElement = array.pop();

        array.unshift(currElement);
    }

    console.log(array.join(' '));
}

Shift(['Banana', 
'Orange', 
'Coconut', 
'Apple', 
'15']);