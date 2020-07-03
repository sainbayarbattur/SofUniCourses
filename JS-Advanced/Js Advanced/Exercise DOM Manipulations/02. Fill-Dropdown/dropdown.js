function addItem() {
    const addButton = document.getElementsByTagName('article')[0].lastChild;
    const value = document.getElementById('newItemValue');
    const text = document.getElementById('newItemText');
    const menu = document.getElementById('menu');

    let option = document.createElement('option');
    option.textContent = text.value;
    option.value = value.value;
    menu.appendChild(option);
    
    text.value = '';
    value.value = '';
}