function solve() {
   const checkoutButton = document.getElementsByClassName('checkout')[0];
   const shoppingCard = document.getElementsByClassName('product');
   let output = document.getElementsByTagName('textarea')[0];
   let allButtons = document.getElementsByTagName('button');
   let totalPrice = 0;
   let products = [];

   Array.from(shoppingCard).forEach(sc => {
      const name = sc.getElementsByClassName('product-title')[0].innerHTML;
      const price = sc.getElementsByClassName('product-line-price')[0].innerHTML;
      const button = sc.getElementsByClassName('add-product')[0];

      button.addEventListener('click', function(){
         products.push(name);
         totalPrice+= Number(price);
         output.innerHTML += `Added ${name} for ${price} to the cart.\n`
      });
   });
   
   checkoutButton.addEventListener('click', function(){
      Array.from(allButtons).map(b => b.disabled=true);
      output.innerHTML += `You bought ${products.filter((p, i) => products.indexOf(p) == i).join(', ')} for ${totalPrice.toFixed(2)}.`;
   });
}