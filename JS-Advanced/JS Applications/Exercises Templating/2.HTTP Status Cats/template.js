(() => {
    function createCat(cat, display, li){
        let html = ''
        let template = ''
        if (display === 'none') {
            li.getElementsByTagName('button')[0].innerHTML = `Hide status code`
            template = Handlebars.compile(document.getElementById('cat-template-block').innerHTML)
        }
        else {
            li.getElementsByTagName('button')[0].innerHTML = `Show status code`   
            template = Handlebars.compile(document.getElementById('cat-template-none').innerHTML)
        }

        html = template(cat)

        return html
    }

    addEvent()

    function addEvent(){
        Array.from(document.getElementsByClassName('showBtn')).map(b => b.addEventListener('click', function(e){
            e.preventDefault()

            renderCatTemplate(e)
        }))
    }

    function renderCatTemplate(e) {
        const id = e.path[1].getElementsByClassName('status')[0].id

        const li = Array.from(document.getElementsByTagName('li')).find(x => x.getElementsByClassName('status')[0].id === id)

        const cat = Array.from(window.cats).find(c => c.id === id)

        const display = e.path[1].getElementsByClassName('status')[0].style.display

        const newCat = createCat(cat, display, li)

        li.outerHTML = newCat

        addEvent()
    }
})()