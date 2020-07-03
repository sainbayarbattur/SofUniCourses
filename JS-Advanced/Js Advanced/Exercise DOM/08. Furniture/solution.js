function solve() {
  const buyButton = document.getElementsByTagName('button')[1];
  const output = document.getElementsByTagName('textarea')[1];
  const button = document.getElementsByTagName('button')[0];
  const json = document.getElementsByTagName('textarea')[0];

  button.addEventListener('click', function(){
    let info = JSON.parse(json.value);

    for (let b = 0; b < info.length; b++) {
      const element = info[b];

      let tr = document.createElement('tr');

      const keys = ['img', 'name', 'price', 'decFactor', 'input'];
  
      for (let i = 0; i < keys.length; i++) {
        const key = keys[i];
        let td = document.createElement('td');
        let subElement = document.createElement(key);
        
        if (key === 'img') {
          subElement.src = element[key];
        }
        else if (key === 'input') {
          subElement.type = 'checkbox';
        }
        else{
          subElement.innerHTML = element[key];
        }
  
        td.appendChild(subElement);
        tr.appendChild(td);
      }
  
      document.getElementsByTagName('tbody')[0].appendChild(tr); 
    }
  });

  let products = [];
  let totalPrice = 0;
  let decoration  = 0;
  let count = 0;

  buyButton.addEventListener('click', function(){
    let trElements = Array.from(document.getElementsByTagName('tr'));
    for (let i = 2; i < trElements.length; i++) {
      if (trElements[i].children[4].children[0].checked) {
        products.push(trElements[i].children[1].textContent);
        totalPrice += Number(trElements[i].children[2].textContent);
        decoration += Number(trElements[i].children[3].textContent);
        count++;
      }
    }

    output.value = `Bought furniture: ${products.join(', ')}\n`
    output.value += `Total price: ${totalPrice.toFixed(2)}\n`;
    output.value += `Average decoration factor: ${decoration/count}`;
  });
}