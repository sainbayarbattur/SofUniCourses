function attachEvents() {
    const loadButton = document.getElementsByClassName('load')[0]
    const addButton = document.getElementsByClassName('add')[0]
    const url = `https://fisher-game.firebaseio.com/catches.json`

    let angler = document.getElementsByClassName('angler')[1]
    let weight = document.getElementsByClassName('weight')[1]
    let species = document.getElementsByClassName('species')[1]
    let location = document.getElementsByClassName('location')[1]
    let bait = document.getElementsByClassName('bait')[1]
    let captureTime = document.getElementsByClassName('captureTime')[1]

    addButton.addEventListener('click', function(e){
        e.preventDefault()
        addCatch(e)

        angler.value = ''
        weight.value = ''
        species.value = ''
        location.value = ''
        bait.value = ''
        captureTime.value = ''
    })

    loadButton.addEventListener('click', function(e){
        e.preventDefault()

        document.getElementById('catches').innerHTML = ''

        fetch(url)
        .then(d => d.json())
        .then(d => {
            for (const key in d) {
                let div = returnCatch(d, key)
                let updateButton = createButton('Update', 'update')

                updateButton.addEventListener('click', function(e){
                    e.preventDefault()
                    updateCatch(e)
                })

                let deleteButton = createButton('Delete', 'delete')
                deleteButton.addEventListener('click', function(e){
                    e.preventDefault()
                    deleteCatch(e)
                })

                div.appendChild(updateButton)
                div.appendChild(deleteButton)

                document.getElementById('catches').appendChild(div)
            }
        })
    })
   
    function returnCatch(d, key){
        let div = document.createElement('div')
        div.className = 'catch'
        div.setAttribute('data-id', key)
        div.innerHTML = `<label>Angler</label>` +
        `<input type="text" class="angler" value="${d[key].angler}" />` +
        `<hr>` +
        `<label>Weight</label>` +
        `<input type="number" class="weight" value="${d[key].weight}" />` +
        `<hr>` +
        `<label>Species</label>` +
        `<input type="text" class="species" value="${d[key].species}" />` +
        `<hr>` +
        `<label>Location</label>` +
        `<input type="text" class="location" value="${d[key].location}" />` +
        `<hr>` +
        `<label>Bait</label>` +
        `<input type="text" class="bait" value="${d[key].bait}" />` +
        `<hr>` +
        `<label>Capture Time</label>` +
        `<input type="number" class="captureTime" value="${d[key].captureTime}" />` +
        `<hr>`

        return div
    }

    function createButton(innerHTML, className){
        let button = document.createElement('button')
        button.className = className
        button.innerHTML = innerHTML

        return button 
    }

    function deleteCatch(e){
        let key = e.path[1].getAttribute('data-id')
        fetch(`https://fisher-game.firebaseio.com/catches/${key}.json`, {method:'delete'})
        .then(d => d.json())
        .then(d => {
            document.getElementById('catches').removeChild(e.path[1])
        })
    }

    function updateCatch(e){
        let key = e.path[1].getAttribute('data-id')
        let obj = {
            'angler': e.path[1].getElementsByClassName('angler')[0].value,
            'weight': e.path[1].getElementsByClassName('weight')[0].value,
            'species': e.path[1].getElementsByClassName('species')[0].value,
            'location': e.path[1].getElementsByClassName('location')[0].value,
            'bait': e.path[1].getElementsByClassName('bait')[0].value,
            'captureTime': e.path[1].getElementsByClassName('captureTime')[0].value
        } 

        fetch(`https://fisher-game.firebaseio.com/catches/${key}.json`, {method:'put', body:JSON.stringify(obj)})
        .catch(console.log)
    }

    function addCatch(e){
        e.preventDefault()
        
        let obj = {
            'angler': angler.value,
            'weight': weight.value,
            'species': species.value,
            'location': location.value,
            'bait': bait.value,
            'captureTime' : captureTime.value
        }

        fetch(url, {method:'post', body:JSON.stringify(obj)})
    }
}

attachEvents();