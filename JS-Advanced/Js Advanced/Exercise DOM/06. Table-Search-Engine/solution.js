function solve() {
   const button = document.getElementById('searchBtn');
   const input = document.getElementById('searchField');
   const data = document.getElementsByTagName('tbody')[0];

   button.addEventListener('click', function(){
      Array.from(data.children).map(d => d.className = '');

      let string = input.value;

      for (let i = 0; i < data.rows.length; i++) {
         for (let b = 0; b < data.children[i].cells.length; b++) {
            let cell = data.children[i].children[b].innerHTML;

            if (cell.toLowerCase().includes(string.toLowerCase())) {
               data.children[i].className = 'select';
               break;
            }
         }
      }
    
      input.value = "";
   });
}