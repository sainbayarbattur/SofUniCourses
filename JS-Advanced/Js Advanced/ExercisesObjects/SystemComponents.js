function Print(array){

    let object = array.reduce((db, componentData) => {
        let [systemName, componentName, subcomponentName] = componentData.split(' | ').map(x => x.trim());

        if (!db[systemName]) {
            db[systemName] = {[componentName]: [subcomponentName]};
            return db;
        }

        if (!db[systemName][componentName]) {
            db[systemName][componentName] = [subcomponentName];
            return db;
        }

        db[systemName][componentName] = [...db[systemName][componentName], subcomponentName];
        return db;

    }, {});

    let sortedArrays = Object.keys(object);

    sortedArrays.sort();

    sortedArrays.sort((a, b) => Object.keys(object[b]).length - Object.keys(object[a]).length)

    for (let i = 0; i < sortedArrays.length; i++) {

        console.log(sortedArrays[i]);

        let componentNamekeys = Object.keys(object[sortedArrays[i]])
        .sort((a, b) => object[sortedArrays[i]][b].length - object[sortedArrays[i]][a].length);

        for (let b = 0; b < componentNamekeys.length; b++) {

            console.log('|||' + componentNamekeys[b]);

            let subcomponentNameKeys = object[sortedArrays[i]][componentNamekeys[b]];

            for (let c = 0; c < subcomponentNameKeys.length; c++) {

                console.log('||||||' + subcomponentNameKeys[c]);
            }
        }
    }
}

Print(['SULS | Main Site | Home Page',
'SULS | Main Site | Login Page',
'SULS | Main Site | Register Page',
'SULS | Judge Site | Login Page',
'SULS | Judge Site | Submittion Page',
'Lambda | CoreA | A23',
'SULS | Digital Site | Login Page',
'Lambda | CoreB | B24',
'Lambda | CoreA | A24',
'Lambda | CoreA | A25',
'Lambda | CoreC | C4',
'Indice | Session | Default Storage',
'Indice | Session | Default Security']
);