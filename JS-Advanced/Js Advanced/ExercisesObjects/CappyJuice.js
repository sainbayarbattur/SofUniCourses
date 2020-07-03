function Print(array){

    var keyValuePairs = [];

    let bottles = {};

    for (let i = 0; i < array.length; i++) {
        
        let line = array[i].split(' => ');

        if (keyValuePairs[line[0]]) {

            keyValuePairs[line[0]] += Number(line[1]);
        }
        else{

            keyValuePairs[line[0]] = Number(line[1]);
        }

        let bottle = Math.floor(keyValuePairs[line[0]] / 1000);

        if (bottle > 0) {
            
            bottles[line[0]] = bottle;
        }
    }

    let stringToReturn = '';

    for (const key in bottles) {

        stringToReturn += key + ' => ' + bottles[key] + '\n';
    }

    return stringToReturn;
}

console.log(Print(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']));