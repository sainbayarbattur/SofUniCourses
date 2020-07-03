function solve() {
    const expresisonOutput = document.getElementById('expressionOutput');
    const resultOutput = document.getElementById('resultOutput');
    const expresisons = ['/', '*', '-', '+'];

    const buttons = document.getElementsByTagName('button');

    let result = '';

    Array.from(buttons).map(b => b.addEventListener('click', function(e){
        let value = e.target.value;

        if (value === '=') {
            try {
                let output = eval(result);
                if (output === undefined || output === Infinity) {
                    resultOutput.innerHTML = NaN;
                }
                else{
                    resultOutput.innerHTML = output;
                }   
            } catch (error) {
                resultOutput.innerHTML = NaN;
            }
        }
        else if (value === 'Clear') {
            result = "";
            expresisonOutput.innerHTML = "";
            resultOutput.innerHTML = "";
        }
        else{
            let line = '';

            if (expresisons.includes(value)) {
                line += ` ${value} `
            }
            else{
                line += value
            }

            result += line;
            expresisonOutput.innerHTML += line
        }
    }));
}