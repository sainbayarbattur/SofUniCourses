function Print(array){

    let keyValuePairs = [];

    for (let i = 0; i < array.length; i++) {

        let line = array[i].split(':');

        if (Object.keys(keyValuePairs).includes(line[0][0])) {
            
            keyValuePairs[line[0][0]].push(`  ${line[0].trim()}:${line[1]}`);
        }
        else{

            keyValuePairs[line[0][0]] = [];

            keyValuePairs[line[0][0]].push(`  ${line[0].trim()}:${line[1]}`)
        }
        
    }

    let keys = Object.keys(keyValuePairs).sort();

    for (let i = 0; i < keys.length; i++) {

        console.log(keys[i]);

        let values = Object.values(keyValuePairs[keys[i]]).sort();

        console.log(values.join('\n'))
    }
}

Print(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);