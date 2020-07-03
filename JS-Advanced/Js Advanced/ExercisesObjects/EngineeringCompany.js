function Print(array){

    let keyValuePairs = [];

    for (let i = 0; i < array.length; i++) {

        let line = array[i].split(' | ');

        if (Object.keys(keyValuePairs).includes(line[0])) {
         
            let duplicate = keyValuePairs[line[0]].filter(function(vendor){ return vendor.model === line[1] });

            if (duplicate.length > 0) {
                
                let index = keyValuePairs[line[0]].indexOf(duplicate[0])

                keyValuePairs[line[0]][index].carproduced += Number(line[2]);

                continue;
            }

            keyValuePairs[line[0]].push({model:line[1], carproduced: Number(line[2])});
        }
        else{

            keyValuePairs[line[0]] = [];

            keyValuePairs[line[0]].push({model:line[1], carproduced:Number(line[2])});
        }
    }

    for (const key in keyValuePairs) {

        console.log(key);

        for (let i = 0; i < keyValuePairs[key].length; i++) {

            console.log('###' + keyValuePairs[key][i].model + ' -> ' + keyValuePairs[key][i].carproduced);   
        }       
    }
}

Print(['Mercedes-Benz | 50PS | 123',
    'Mini | Clubman | 20000',
    'Mini | Convertible | 1000',
    'Mercedes-Benz | 60PS | 3000',
    'Hyunday | Elantra GT | 20000',
    'Mini | Countryman | 100',
    'Mercedes-Benz | W210 | 100',
    'Mini | Clubman | 1000',
    'Mercedes-Benz | W163 | 200']
);