function solve() {
    let result = document.getElementById('result');
    let [key, ...line] = JSON.parse(document.getElementById('array').value); 

    let regex = new RegExp(`${key}[ ]+([!%#A-Z\$]{8,})([\., ]|$)`, 'gim');

    line.forEach(dataLine => {
        let replacedLine = dataLine;

        if (dataLine.match(regex)) {
            let matches = dataLine.match(regex)
            .map(x => x.split(' ')[1])
            .filter(str => str === str.toUpperCase())
            .map(x => {
                let parsedWord = x.replace('!', 1)
                .replace('%', 2)
                .replace('#', 3)
                .replace('$', 4)
                .toLowerCase()
    
                replacedLine = replacedLine.replace(x, parsedWord)
            })   
        }
        let p = document.createElement('p');
        p.textContent = replacedLine
        result.appendChild(p);
    });
}