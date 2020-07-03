function solve() {
    let key = document.getElementById('string').value;
    let message = document.getElementById('text').value;
    const messagee = message.match(`${key}(.+)${key}`);
    let result = document.getElementById('result');

    let regex = new RegExp(/(?<direction>east|north).*?(?<cooordinate>\d{2})[^,]*?,[^,]*?(?<decimal>\d{6})/gmi);

    let northMatch
    let eastMatch
    let curr

    while ((curr = regex.exec(message)) !== null) {
        if (curr[1].toLowerCase() === 'east') {
            eastMatch = `${curr[2]}.${curr[3]}`;
        }
        else{
            northMatch = `${curr[2]}.${curr[3]}`;
        }
    }
    
    result.innerHTML = `
    <p>${northMatch} N</p>
    <p>${eastMatch} E</p>
    <p>Message: ${messagee[1]}</p>`
}