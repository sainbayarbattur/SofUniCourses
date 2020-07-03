function notify(message) {
    let messageBox = document.getElementById('notification');
    messageBox.innerHTML = message;

    messageBox.style.display = 'block';

    setTimeout(function(){messageBox.style.display = 'none'}, 2000);
}