function solve() {
   let player1 = document.getElementById('player1Div');
   let player2 = document.getElementById('player2Div');
   let result = document.getElementById('result');
   let history = document.getElementById('history');

   let card1;
   let card2;

   [player1, player2].forEach(p => p.addEventListener('click', function(e){
      let value = e.target.name;

      e.target.src = 'images/whiteCard.jpg';

      if (card1 === undefined && card2 === undefined) {
         result.children[0].textContent = '';
         result.children[2].textContent = '';   
      }

      if (p === player1) {
         card1 = e.target;
         result.children[0].textContent = value;
      }
      else{
         card2 = e.target;
         result.children[2].textContent = value;
      }

      if (card1 !== undefined && card2 !== undefined && Number(card1.name) > Number(card2.name)) {
         card1.style.border = '2px solid green';
         card2.style.border = '2px solid red';
      }
      else if (card1 !== undefined && card2 !== undefined && Number(card1.name) < Number(card2.name)) {
         card2.style.border = '2px solid green';
         card1.style.border = '2px solid red';
      }

      if (card1 !== undefined && card2 !== undefined) {
         history.innerHTML += `[${Number(card1.name)} vs ${Number(card2.name)}] `
         card1 = undefined;
         card2 = undefined;
      }
   }))
}