function attachEventsListeners() {
    const outputUnits = document.getElementById('outputUnits');
    const inputUnits = document.getElementById('inputUnits');
    const output = document.getElementById('outputDistance');

    document.getElementById('convert').addEventListener('click', function(){
        let number = document.getElementById('inputDistance').value;
        if (inputUnits.value == 'km') {
            number *= 1;
        }
        else if (inputUnits.value == 'm') {
            number /= 1000;
        }
        else if (inputUnits.value == 'cm') {
            number /= 100000;
        }
        else if (inputUnits.value == 'mm') {
            number /= 1000000;
        }
        else if (inputUnits.value == 'mi') {
            number /= 0.621371;
        }
        else if (inputUnits.value == 'yrd') {
            number /= 1093.61;
        }
        else if (inputUnits.value == 'ft') {
            number /= 3280.84;
        }
        else if (inputUnits.value == 'in') {
            number /= 39370.1;
        }

        if (outputUnits.value == 'km') {
            output.value = number;
        }
        else if (outputUnits.value == 'm') {
            output.value = number * 1000;
        }
        else if (outputUnits.value == 'cm') {
            output.value = number * 100000;
        }
        else if (outputUnits.value == 'mm') {
            output.value = number * 1000000;
        }
        else if (outputUnits.value == 'mi') {
            output.value = number * 0.621371;
        }
        else if (outputUnits.value == 'yrd') {
            output.value = number * 1093.61;
        }
        else if (outputUnits.value == 'ft') {
            output.value = number * 3280.84;
        }
        else if (outputUnits.value == 'in') {
            output.value = number * 39370.1;
        }
    });
}