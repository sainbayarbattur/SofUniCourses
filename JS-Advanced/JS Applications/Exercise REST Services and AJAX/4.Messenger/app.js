function attachEvents() {
    const submitButton = document.getElementById('submit')
    const refreshButton = document.getElementById('refresh')
    const textarea = document.getElementById('messages')
    const author = document.getElementById('author')
    const content = document.getElementById('content')
    const url = `https://augmented-path-230517.firebaseio.com/messenger.json`


    submitButton.addEventListener('click', function(e){
        e.preventDefault()

        let obj = {
            'author': author.value,
            'content': content.value,
        }

        fetch(url, {method:'post', body:JSON.stringify(obj)})
        .then(d => d.json())
        .then(d => {
            author.value = ''
            content.value = ''
        })
    })

    refreshButton.addEventListener('click', function(e){
        e.preventDefault()

        
        fetch(url)
        .then(d => d.json())
        .then(d => {
            for (const key in d) {
                textarea.innerHTML += d[key].author + ': ' + d[key].content + '\n'
            }
        })
    })

}

attachEvents();