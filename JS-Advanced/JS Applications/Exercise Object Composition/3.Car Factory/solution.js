function main(object){
    let engine = {}
    let carriage = {}
    let wheels = []
    for (let i = 0; i < 4; i++) {
        if (Number(object.wheelsize)%2 === 0) {
            wheels.push(2* Math.round(object.wheelsize/2) - 1)
        }
        else{
            wheels.push(object.wheelsize)
        }
    }

    if (Math.abs(object.power - 90) < Math.abs(object.power - 120) && Math.abs(object.power - 90) < Math.abs(object.power - 200)) {
        engine = { power: 90, volume: 1800 }
    }
    else if (Math.abs(object.power - 120) < Math.abs(object.power - 90) && Math.abs(object.power - 120) < Math.abs(object.power - 200)) {
        engine = { power: 120, volume: 2400 }
    }
    else{
        engine = { power: 200, volume: 3500 }
    }

    switch (object.carriage) {
        case 'hatchback':
            carriage = { type: 'hatchback', color: object.color }
            break;
        case 'coupe':
            carriage = { type: 'coupe', color: object.color }
            break
    }

    let f = { model: object.model,
    engine: engine,
    carriage: carriage,
    wheels: wheels }

    return f
}

console.log(main({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}))