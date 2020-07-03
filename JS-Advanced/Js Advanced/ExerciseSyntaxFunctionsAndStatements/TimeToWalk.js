function Calculate(steps, length, kmh){

    //km
    let distance = (steps * length);

    //minute
    let rests = Math.floor(distance / 500);

    let time = distance / kmh / 1000 * 60;

    let totalSeconds = (time + rests) * 60;

    let hours = Math.floor(totalSeconds / 60 / 60);

    let minutes = Math.floor((totalSeconds - hours) / 60);

    let seconds = Math.floor(totalSeconds - ((hours * 60) + minutes) * 60) + 1;

    hours = (hours < 10 ? '0' : '') + hours;

    minutes = (minutes < 10 ? '0' : '') + minutes;

    seconds = (seconds < 10 ? '0' : '') + seconds;

    console.log(hours + ':' + minutes + ':' + seconds);
}

console.log(Calculate(2564, 0.70, 5.5));