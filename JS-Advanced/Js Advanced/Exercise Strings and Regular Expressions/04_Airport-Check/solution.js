function solve() {
    let string = document.getElementById('string');
    let outputLabel = string.value.split(',')[1]

    let nameRegex = /[A-Z][A-Za-z]*-[A-Z][A-Za-z]*( |\.-[A-Z][A-Za-z]* )/gm
    let airportRegex = / [A-Z]{3}\/[A-Z]{3} /gm
    let flightNumberRegex = / [A-Z]{1,3}[\d]{1,5} /gm
    let companyRegex = /- [A-Z][A-Za-z]*\*[A-Z][A-Za-z]* /gm

    let name = string.value.match(nameRegex)[0].trim().replace(/-/g, ' ')
    let [from, to] = string.value.match(airportRegex)[0].split('/')
    let flightNumber = string.value.match(flightNumberRegex)[0].trim()
    let company = string.value.match(companyRegex)[0].trim().replace('- ', '').replace('*', ' ')

    if (outputLabel.includes('all')) {
        document.getElementById('result').textContent = `Mr/Ms, ${name}, your flight number ${flightNumber} is from ${from.trim()} to ${to.trim()}. Have a nice flight with ${company}.`;
    }
    else if (outputLabel.includes('name')) {
        document.getElementById('result').textContent = `Mr/Ms, ${name}, have a nice flight!`;
    }
    else if (outputLabel.includes('flight')) {
        document.getElementById('result').textContent = `Your flight number ${flightNumber} is from ${from.trim()} to ${to.trim()}.`;
    }
    else if (outputLabel.includes('company')) {
        document.getElementById('result').textContent = `Have a nice flight with ${company}.`;
    }
}