let solution = function(){

    let system = [];

    system['protein'] = 0;
    system['carbohydrate'] = 0;
    system['fat'] = 0;
    system['flavour'] = 0;

    return function(line){

        let info = line.split(' ');

        let proteins = system['protein'];

        let carbs = system['carbohydrate'];

        let fats = system['fat'];

        let flavours = system['flavour'];

        if (info[0] == 'restock') {
            system[info[1]] = Number(info[2]);
        }
        else if (info[0] == 'prepare') {
            if (info[1] == 'apple') {
                if (carbs >= 1 * Number(info[2])
                    && flavours >= 2 * Number(info[2])) {
                    system['carbohydrate'] -= 1 * Number(info[2]) ;
                    system['flavour'] -= 2 * Number(info[2]);
                }
                else{
                    return `Error: not enough ${carbs >= 1 ? 'flavour' : 'carbohydrate'} in stock`;
                }
            }
            else if (info[1] == 'lemonade') {
                if (carbs >= 10 * Number(info[2])
                    && flavours >= 20 * Number(info[2])) {
                    system['carbohydrate'] -= 10 * Number(info[2]);
                    system['flavour'] -= 20 * Number(info[2])
                }
                else{
                    return `Error: not enough ${carbs >= 10 ? 'flavour' : 'carbohydrate'} in stock`;
                }

            }
            else if (info[1] == 'burger') {
                if (carbs >= 5 * Number(info[2])
                    && fats >= 7 * Number(info[2])
                    && flavours >= 3 * Number(info[2])) {
                    system['carbohydrate'] -= 5 * Number(info[2]);
                    system['fat'] -= 7 * Number(info[2]);
                    system['flavour'] -= 3 * Number(info[2]);
                }
                else{
                    return `Error: not enough ${carbs < 5 ? 'carbohydrate' : fats < 7 ? 'fat' : 'flavour' } in stock`;
                }
            }
            else if (info[1] == 'eggs') {
                if (proteins >= 5 * Number(info[2])
                    && flavours >= 1 * Number(info[2])
                    && fats >= 1 * Number(info[2])) {
                    
                    system['protein'] -= 5 * Number(info[2]);
                    system['flavour'] -= 1 * Number(info[2]);
                    system['fat'] -= 1 * Number(info[2]);
                }
                else{
                    return `Error: not enough ${proteins < 5 ? 'protein' : fats < 1 ? 'fat' : 'flavour' } in stock`;
                }
            }
            else{
                if (carbs >= 10 * Number(info[2])
                    && fats >= 10 * Number(info[2])
                    && proteins >= 10 * Number(info[2])
                    && flavours >= 10 * Number(info[2])) {
                    
                    system['protein'] -= 10 * Number(info[2]);                    
                    system['flavour'] -= 10 * Number(info[2]);                    
                    system['carbohydrate'] -= 10 * Number(info[2]);                    
                    system['fat'] -= 10 * Number(info[2]);
                }
                else{
                    return `Error: not enough ${proteins < 10 ? 'protein' : carbs < 10 ? 'carbohydrate' : fats < 10 ? 'fat' : 'flavour' } in stock`;
                }
            }
        }
        else{
            return `protein=${system['protein']} carbohydrate=${system['carbohydrate']} fat=${system['fat']} flavour=${system['flavour']}`;
        }

        return 'Success';
    }
}

let manager = solution();

console.log(manager('restock protein 100'));
console.log(manager('restock carbohydrate 100'));
console.log(manager('restock fat 100'));

console.log(manager('restock flavour 100'));
console.log(manager('report'));
console.log(manager('prepare apple 2'));

console.log(manager('report'));
console.log(manager('prepare apple 1'));
console.log(manager('report'));