 function main(...args){

    let count = {};

    let objects = [];

    args.forEach(a => {

        if (!count.hasOwnProperty(typeof(a))) {
            count[typeof(a)] = 0;
        }

        objects.push(a);

        count[typeof(a)]++;
    });

    let countKeys = Object.keys(count).sort((a, b) => count[b] - count[a]);

    for (let i = 0; i < objects.length; i++) {
        const element = objects[i];

        console.log(`${typeof(element)}: ${element}`);
    }

    for (let i = 0; i < countKeys.length; i++) {

        console.log(`${countKeys[i]} = ${count[countKeys[i]]}`);
    }
};

main(42, 15, 'cat');