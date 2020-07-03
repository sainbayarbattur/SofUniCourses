function solve(){
    const url = `https://remotedatab.firebaseio.com/books.json`
    
    document.getElementById('loadBooks').addEventListener('click', async function(e){
        load()
    })

    document.getElementById('submit').addEventListener('click', async function(e){
        e.preventDefault()

        let obj = {
            'title': document.getElementById('title').value,
            'author': document.getElementById('author').value,
            'isbn': document.getElementById('isbn').value,
            'tag': document.getElementById('tag').value
        }
        
        let headers = {
            method:'post', 
            body:JSON.stringify(obj)
        }

        fetch(url, headers)
        .then(d => d.json())
        .then(d => {
            document.getElementById('title').value = ''
            document.getElementById('author').value = ''
            document.getElementById('isbn').value = ''
            document.getElementById('tag').value = ''
            load(e)
        })
    })

    function deleteFunc(e){
        e.preventDefault()

        let id = e.path[2].id

        let headers = {
            method:'delete'
        }

        fetch(`https://remotedatab.firebaseio.com/books/${id}.json`, headers)

        document.getElementsByTagName('tbody')[0].removeChild(e.path[2])
    }

    function generate(obj, id){
        let tr = document.createElement('tr')
        tr.id = id

        let title = document.createElement('td')
        title.className = 'title'
        title.innerHTML = obj.title

        let author = document.createElement('td')
        author.className = 'author'
        author.innerHTML = obj.author 

        let isbn = document.createElement('td')
        isbn.className = 'isbn'
        isbn.innerHTML = obj.isbn

        let tag = document.createElement('td')
        tag.className = 'tag'
        tag.innerHTML = obj.tag

        tr.appendChild(title)
        tr.appendChild(author)
        tr.appendChild(isbn)
        tr.appendChild(tag)

        Array.from(tr.children).forEach(ele => {
            ele.addEventListener('click', function(e){
                e.preventDefault()

                document.getElementById('title').value = obj.title
                document.getElementById('author').value = obj.author
                document.getElementById('isbn').value = obj.isbn
                document.getElementById('tag').value = obj.tag

                document.getElementById('change').addEventListener('click', function(eTag){
                    eTag.preventDefault()
                    changeTag(e, e.path[1].id)
                })
            })
        });

        let buttons = document.createElement('td')

        let editButton = document.createElement('button')
        editButton.innerHTML = 'Edit'
        editButton.addEventListener('click', function(e){
            e.preventDefault()
            updateFunc(e)
        })

        let deleteButton = document.createElement('button')
        deleteButton.innerHTML = 'Delete'
        deleteButton.addEventListener('click', deleteFunc)

        buttons.appendChild(editButton)
        buttons.appendChild(deleteButton)

        tr.appendChild(buttons)

        return tr
    }

    function updateFunc(e){
        let obj = {
            'title': document.getElementById('title').value,
            'author': document.getElementById('author').value,
            'isbn': document.getElementById('isbn').value,
        }
        
        let headers = {
            method:'put', 
            body:JSON.stringify(obj)
        }

        let id = e.path[2].id

        fetch(`https://remotedatab.firebaseio.com/books/${id}.json`, headers)

        document.getElementById('title').value = ''
        document.getElementById('author').value = ''
        document.getElementById('isbn').value = ''
        
        document.getElementById(e.path[2].id).getElementsByClassName('title')[0].innerHTML = obj.title
        document.getElementById(e.path[2].id).getElementsByClassName('author')[0].innerHTML = obj.author
        document.getElementById(e.path[2].id).getElementsByClassName('isbn')[0].innerHTML = obj.isbn
    }

    async function load(){
        document.getElementsByTagName('tbody')[0].innerHTML = ''

        const request = await fetch(url)

        const books = await request.json()

        for (const key in books) {
            let tr = generate(books[key], key)
            document.getElementsByTagName('tbody')[0].appendChild(tr)
        }
    }

    function changeTag(e, id){
        e.preventDefault()

        let body = {
            tag: document.getElementById('tag').value,
        }

        let headers = {
            method:'PATCH',
            body: JSON.stringify(body)
        }

        fetch(`https://remotedatab.firebaseio.com/books/${id}.json`, headers)

        document.getElementById(id).getElementsByClassName('tag')[0].innerHTML = document.getElementById('tag').value
    }
}