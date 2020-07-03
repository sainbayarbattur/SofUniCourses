function subtract() {
    const firstNumber = (Number)(document.getElementById('firstNumber').value);
    const secondNumber = (Number)(document.getElementById('secondNumber').value);

    document.getElementById('result').innerHTML = firstNumber - secondNumber;
}