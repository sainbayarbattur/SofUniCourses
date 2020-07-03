function solve() {
    const input = document.getElementsByTagName('input')[0];
    const button = document.getElementsByTagName('button')[0];

    button.addEventListener('click', function(){
        let index = input.value.toLowerCase().charCodeAt(0) - 97;

        let list = document.getElementsByTagName('ol')[0];

        let string = input.value[0].toUpperCase() + input.value.substring(1).toLowerCase();

        if (list.children[index].innerHTML != "") {
            list.children[index].innerHTML += ', ' + string;  
        }
        else{
            list.children[index].innerHTML += string; 
        }

        input.value = "";
    });
}