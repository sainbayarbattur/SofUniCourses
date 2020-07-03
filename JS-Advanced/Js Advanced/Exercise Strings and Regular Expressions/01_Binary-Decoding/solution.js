function solve() {
	let input = document.getElementById('input').value;
	let sumAllNumbers = 0;
	let sumDigitsNumber = 0;
	let result = '';
	Array.from(input).map((v) => Number(v)).forEach(v => sumAllNumbers += v)
	sumDigits = sumDigits(sumAllNumbers);

	input = input.substring(sumDigits, input.length - sumDigits)

	for (let i = 0; i < input.length/8; i++) {
		if (new RegExp("^[A-Za-z' ']+$").test(binaryAgent(input.substring(i*8, i*8 + 8)))) {
			result += binaryAgent(input.substring(i*8, i*8 + 8));	
		}
	}

	document.getElementById('resultOutput').innerHTML = result;

	function binaryAgent(str) {
		return String.fromCharCode(parseInt(str, 2))
	}

	function sumDigits(n) {
		return (n - 1) % 9 + 1;
	}
}