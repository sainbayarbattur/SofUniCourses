function Main(info, attack){
    let system = {};

    for (let i = 0; i < info.length; i++) {
        let object = info[i];

        let kingdomName = object['kingdom'];
        let generalName = object['general'];
        let army = object['army'];

        if (!system[kingdomName]) {
            system[kingdomName] = {totalWins:0, totallosses:0};
        }

        if (!system[kingdomName][generalName]) {
            system[kingdomName][generalName] = {army:0, wins:0, losses:0};
        }

        system[kingdomName][generalName].army += army;
    }

    for (let i = 0; i < attack.length; i++) {
        const line = attack[i];

        let attackingKingdom = line[0];
        let attackingGeneral = line[1];
        let defendingKingdom = line[2];
        let defendingGeneral = line[3];

        if (attackingKingdom != defendingKingdom) {
            if (system[attackingKingdom][attackingGeneral].army > system[defendingKingdom][defendingGeneral].army) {

                system[attackingKingdom].totalWins++;
                system[defendingKingdom].totallosses++;
                system[attackingKingdom][attackingGeneral].wins++;
                system[defendingKingdom][defendingGeneral].losses++;

                system[attackingKingdom][attackingGeneral].army = Math.floor(system[attackingKingdom][attackingGeneral].army
                    + system[attackingKingdom][attackingGeneral].army * 0.1);

                system[defendingKingdom][defendingGeneral].army = Math.floor(system[defendingKingdom][defendingGeneral].army
                    - system[defendingKingdom][defendingGeneral].army * 0.1);
            }
            else if (system[attackingKingdom][attackingGeneral].army < system[defendingKingdom][defendingGeneral].army) {

                system[defendingKingdom].totalWins++;
                system[attackingKingdom].totallosses++;
                system[attackingKingdom][attackingGeneral].losses++;
                system[defendingKingdom][defendingGeneral].wins++;

                system[defendingKingdom][defendingGeneral].army = Math.floor(system[defendingKingdom][defendingGeneral].army
                    + system[defendingKingdom][defendingGeneral].army * 0.1);

                 system[attackingKingdom][attackingGeneral].army = Math.floor(system[attackingKingdom][attackingGeneral].army
                    - system[attackingKingdom][attackingGeneral].army * 0.1);
            }   
        }
    }

    let kingdoms = Object.keys(system)

    kingdoms.sort();

    kingdoms.sort((a, b) => system[a].totallosses - system[b].totallosses);

    kingdoms.sort((a, b) => system[b].totalWins - system[a].totalWins);

    let generals = Object.keys(system[kingdoms[0]]).filter(k => k != 'totalWins' && k != 'totallosses');
    
    generals.sort((a, b) => system[kingdoms[0]][b].army - system[kingdoms[0]][a].army);

    generals.sort((a, b) => system[kingdoms[0]][b].totalWins - system[kingdoms[0]][a].totalWins);

    console.log('Winner: ' + kingdoms[0]);

    for (let i = 0; i < generals.length; i++) {
        console.log(`/\\general: ${generals[i]}`);
        
        let prop = Object.keys(system[kingdoms[0]][generals[i]])

        for (let b = 0; b < prop.length; b++) {
         
            console.log(`---${prop[b]}: ${system[kingdoms[0]][generals[i]][prop[b]]}`);
        }
    }
}

Main([ { kingdom: "Maiden Way", general: "Merek", army: 5000 },
{ kingdom: "Stonegate", general: "Ulric", army: 4900 },
{ kingdom: "Stonegate", general: "Doran", army: 70000 },
{ kingdom: "YorkenShire", general: "Quinn", army: 0 },
{ kingdom: "YorkenShire", general: "Quinn", army: 2000 },
{ kingdom: "Maiden Way", general: "Berinon", army: 100000 } ],
[ ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
["Stonegate", "Ulric", "Stonegate", "Doran"],
["Stonegate", "Doran", "Maiden Way", "Merek"],
["Stonegate", "Ulric", "Maiden Way", "Merek"],
["Maiden Way", "Berinon", "Stonegate", "Ulric"] ]);