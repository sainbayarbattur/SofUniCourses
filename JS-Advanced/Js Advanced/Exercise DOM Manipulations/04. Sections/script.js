function create(words) {
   for (let i = 0; i < words.length; i++) {
      let div = document.createElement('div'); 
      let paragraph = document.createElement('p'); 
      paragraph.textContent = words[i]; 
      paragraph.style.display = 'none';
      div.appendChild(paragraph);
      document.getElementById('content').appendChild(div);
   }

   document.getElementById('content').addEventListener('click', function(e){
      let div = e.target;
      div.children[0].style.display = 'block';
   });
}