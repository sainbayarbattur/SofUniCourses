function solve() {
   const button = document.getElementById('send');
   const chatBox = document.getElementById('chat_messages'); 

   button.addEventListener('click', function(){
      const input = document.getElementById('chat_input').value;

      let messageBox = document.createElement('div');

      let message = document.createTextNode(input);

      messageBox.classList.add('message');
      messageBox.classList.add('my-message');

      messageBox.appendChild(message);
      chatBox.appendChild(messageBox);

      document.getElementById('chat_input').value = "";
   });
}