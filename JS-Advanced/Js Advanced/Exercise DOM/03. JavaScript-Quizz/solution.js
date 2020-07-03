function solve() {
    let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
    let result = document.getElementsByClassName('results-inner')[0];
    let sections = document.getElementsByTagName('section');
    let correctAnswersCount = 0;
    let i = 0;

    Array.from(document.querySelectorAll('.answer-text'))
    .map(a => a.addEventListener('click', function(e){
        if (correctAnswers.includes(e.target.innerHTML)) {
            correctAnswersCount++;
        }

        sections[i].style.display = "none";

        if (sections[i + 1] !== undefined) {
            i++;
            sections[i].style.display = "block";
        }
        else{
            document.getElementById("results").style.display = "block";
            if (correctAnswersCount != 3) {
                result.children[0].innerHTML =
                    `You have ${correctAnswersCount} right answers`;
            } else {
                result.children[0].innerHTML =
                    "You are recognized as top JavaScript fan!";
            }
        }
    }))
}
