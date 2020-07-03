function ModifyInteger(array){

    let number = array[0];

    for (let index = 1; index < array.length; index++) {
        
        let command = array[index];

        switch (command) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number++;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number -= (number * 0.2);
                break;
        }

        console.log(number);
    }
}

ModifyInteger(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);