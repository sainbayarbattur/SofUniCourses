function showNotification(type, message) {
    fetch(`./views/notifications/${type}.hbs`)
        .then(response => response.text())
        .then(response => {
            let html = response.replace('message', message)
            document.getElementById('notifications').innerHTML = html
        })
}

function deleteNotification() {
    document.getElementById('notifications').innerHTML = ''
}