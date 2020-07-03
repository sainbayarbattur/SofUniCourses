function solve(){
   const elements = document.getElementsByTagName('tbody')
   console.log()

   Array.from(elements[0].children).map(tr => tr.addEventListener('click', function(e){
      e.preventDefault()

      if (tr.style.backgroundColor === 'rgb(65, 63, 94)') {
         tr.style = 'none'
      }
      else{
         Array.from(elements[0].children).map(c => c.style = 'none')
         tr.style.backgroundColor = '#413f5e'
      }
   }))
}