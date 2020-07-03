function Print(array){

    const motorwayLimit = 130;
    const interstateLimit = 90;
    const cityLimit = 50;
    const residentialLimit = 20;

    let kmh = array[0];
    
    let area = array[1];

    let diff = 0;

    switch (area) {
        case 'city':
            diff = kmh - cityLimit;
            break;
        case 'interstate':
            diff = kmh - interstateLimit;
            break;
        case 'residential':
            diff = kmh - residentialLimit;
            break;
        case 'motorway':
            diff = kmh - motorwayLimit;
            break;
    }

    if (diff == 0) {
        console.log('');
        return;
    }

    if ((diff <= 20 && diff > 0)) {
        console.log('speeding')
        return;
    }

    if ((diff <= 40 && diff > 0)) {
        console.log('excessive speeding');
        return;
    }

    console.log('reckless driving');
}

console.log(Print([200, 'motorway']));