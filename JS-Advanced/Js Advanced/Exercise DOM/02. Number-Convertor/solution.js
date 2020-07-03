function solve() {
    const button = document.getElementsByTagName('button')[0];
    const input = document.getElementById('input');
    const selectMenu = document.getElementById('selectMenuTo');

    let binary = document.createElement('option');
    binary.innerText = 'Binary'
    binary.value = 'binary'

    let hexadeicmal = document.createElement('option');
    hexadeicmal.innerText = 'Hexadecimal'
    hexadeicmal.value = 'hexadecimal'

    selectMenu.appendChild(binary);
    selectMenu.appendChild(hexadeicmal);

    button.addEventListener('click', function(){
        let convertTo = selectMenu.value;
        let number = input.value;

        if (convertTo === 'binary') {
            document.getElementById('result').value = Number(number).toString(2);
        }
        else if (convertTo === 'hexadecimal') {
            document.getElementById('result').value = Number(number).toString(16).toUpperCase();
        }
    });
}