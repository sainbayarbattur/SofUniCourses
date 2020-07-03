function Main(input){

    let arena = [];

    let sum = function(a){
        let y = 0;

        for (const key in arena[a]) {
            y += arena[a][key];
        }

        return y;
    }

    for (let i = 0; i < input.length; i++) {
        let line = input[i].split(' ');

        if (line.includes('->')) {
            let gladiatorName = line[0];

            let gladiatorTechnique = line[2];

            let gladiatorSkill = Number(line[4])

            if (!arena[gladiatorName]) {
                arena[gladiatorName] = {[gladiatorTechnique]: gladiatorSkill};
            }
            else if (!arena[gladiatorName][gladiatorTechnique]) {
                arena[gladiatorName][gladiatorTechnique] = gladiatorSkill;
            }
            else if (arena[gladiatorName][gladiatorTechnique] < gladiatorSkill){
                arena[gladiatorName][gladiatorTechnique] = gladiatorSkill;   
            }
        }
        else if (line.includes('vs')){
            let gladiatorName = line[0]

            let gladiatorName1 = line[2];

            if (arena[gladiatorName] && arena[gladiatorName1]){

                for (const key1 in arena[gladiatorName]) {
                    
                    for (const key2 in arena[gladiatorName1]) {

                        if (key1 == key2) {

                            if (sum(gladiatorName) > sum(gladiatorName1)) {
                                delete arena[gladiatorName1];
                            }
                            else if (sum(gladiatorName1) > sum(gladiatorName)) {
                                delete arena[gladiatorName];
                            }
                        }
                    }
                }
            }
        }
        else{
            let keysGladiator = Object.keys(arena);

            keysGladiator.sort((a, b) => sum(b) - sum(a) || a.localeCompare(b));

            for (let b = 0; b < keysGladiator.length; b++) {

                console.log(`${keysGladiator[b]}: ${sum(keysGladiator[b])} skill`);

                let keysSkill = Object.keys(arena[keysGladiator[b]]);

                keysSkill.sort((j, d) => arena[keysGladiator[b]][d] - arena[keysGladiator[b]][j] || j.localeCompare(d));

                for (let c = 0; c < keysSkill.length; c++) {
                    console.log(`- ${keysSkill[c]} <!> ${arena[keysGladiator[b]][keysSkill[c]]}`);
                }
            }
        }
    }
}

// Main(['Pesho -> Duck -> 400',
// 'Pesho -> Duck -> 500',
// 'Pesho -> Duck -> 100',
// 'Pesho vs Gogo',
// 'Ave Cesar'])

// Main(['Pesho -> Duck -> 400',
//     'Julius -> Shield -> 150',
//     'Gladius -> Heal -> 200',
//     'Gladius -> Support -> 250',
//     'Gladius -> Shield -> 250',
//     'Pesho vs Gladius',
//     'Gladius vs Julius',
//     'Gladius vs Gosho',
//     'Ave Cesar'
//     ]);

Main(['Pesho -> BattleCry -> 400',
    'Gosho -> PowerPunch -> 300',
    'Stamat -> Duck -> 200',
    'Stamat -> Tiger -> 250',
    'Ave Cesar'
    ]);