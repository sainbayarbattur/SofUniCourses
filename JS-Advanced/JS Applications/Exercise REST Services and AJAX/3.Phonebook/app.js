function attachEvents() {
    const url = `https://augmented-path-230517.firebaseio.com/phonebook.json`

    function create(){
        const person = document.getElementById('person').value
        const phone = document.getElementById('phone').value

        let data = {
            person,
            phone
        }            

        fetch(url, {
            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(data),
        })
        .then(() => {
            document.getElementById('person').value = ''
            document.getElementById('phone').value = ''
            document.getElementById('phonebook').innerHTML = ''
            load()
        })
    }

    function load(){
        fetch(url)
        .then(d => d.json())
        .then(d => {
            document.getElementById('phonebook').innerHTML = ''

            for (const key in d) {
                let li = document.createElement('li')
                li.innerHTML = `${d[key].person}: ${d[key].phone}`

                let deleteButton = document.createElement('button')
                deleteButton.textContent = 'Delete'
                deleteButton.id = key
                li.appendChild(deleteButton)

                deleteButton.addEventListener('click', del)

                document.getElementById('phonebook').appendChild(li)
            }
        })
        .catch(() => {console.log('Error')})
    }

    function del(e){
        fetch(`https://augmented-path-230517.firebaseio.com/phonebook/${e.target.id}.json`, {method: "delete"})
        .then(d => {
            document.getElementById('phonebook').removeChild(e.path[1])
        })
        .catch(console.log('Error'))
    
    }

    document.getElementById('btnLoad').addEventListener('click', load)
    document.getElementById('btnCreate').addEventListener('click', create)
}

attachEvents()