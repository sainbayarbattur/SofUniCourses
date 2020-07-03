function Print(array){

    let output = [];

    output.push('<table>\n');

    for (let i = 0; i < array.length; i++) {

        let line = array[i];

        let employee = JSON.parse(line);

        output.push('	<tr>\n');

        output.push(`		<td>${employee.name}</td>\n`);
        output.push(`		<td>${employee.position}</td>\n`);
        output.push(`		<td>${employee.salary}</td>\n`);

        output.push('	</tr>\n');
        
    }

    output.push('</table>\n');

    let stringToReturn = '';

    for (let i = 0; i < output.length; i++) {

        stringToReturn += output[i];
    }

    return stringToReturn;
}

console.log(Print(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']
));