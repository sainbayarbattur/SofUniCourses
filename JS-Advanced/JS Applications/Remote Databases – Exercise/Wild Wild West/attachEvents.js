const url = 'https://wildwest-1100d.firebaseio.com/players.json'
function attachEvents() {
    render()
    var obj = {}

    async function addPlayer(){
        render()

        const body = {
            name:document.getElementById('addName').value,
            money:500,
            bullets:6,
        }

        const headers = {
            method:'post',
            'Content-Type':'application/json',
            body: JSON.stringify(body)
        }

        const query = await fetch(url, headers)
        const response = await query.json()
        console.log(response)

        document.getElementById('addName').value = ''
    }

    async function render(){
        var query = await fetch('https://wildwest-1100d.firebaseio.com/.json')
        const players = await query.json()

        query = await fetch('http://127.0.0.1:5500/player.hbs')
        const template = await query.text()

        const handlebars = Handlebars.compile(template)
        let playersHtml = handlebars(players)

        document.getElementById('players').innerHTML = playersHtml
    }
    
    async function deletePlayer(id){
        const headers = {
            method:'delete'
        }

        await fetch(`https://wildwest-1100d.firebaseio.com/players/${id}.json`, headers)

        document.getElementById('players').removeChild(document.getElementById(id))
    }

    function showButtons(){
        document.getElementById('save').style = 'display: block; display:inline'
        document.getElementById('reload').style = 'display: block; display:inline'
    }

    function hideButtons(){
        document.getElementById('save').style.display = 'none'
        document.getElementById('reload').style.display = 'none'
    }
    
    function play(id){
        hideButtons()
        showButtons()

        const canvas = document.getElementById('canvas')
        const context = canvas.getContext("2d")

        context.clearRect(0, 0, canvas.width, canvas.height);

        fetch(`https://wildwest-1100d.firebaseio.com/players/${id}.json`)
        .then(re => re.json())
        .then(player => {
            clearInterval(canvas.intervalId);

            obj = {player, id}

            canvas.style.display = 'block'
            loadCanvas(player)
        })
    }

    function save(){
        const body = {
            name: obj.player.name,
            money: obj.player.money,
            bullets: obj.player.bullets,
        }

        const headers = {
            method:'put',
            body:JSON.stringify(body)
        }

        fetch(`https://wildwest-1100d.firebaseio.com/players/${obj.id}.json`, headers)
        .then(re => {
            clearInterval(canvas.intervalId);
        })
    }

    function reload(){
        if (obj.player.money > 60) {
            const body = {
                name: obj.player.name,
                money: obj.player.money - 60,
                bullets: obj.player.bullets + 6,
            }
    
            const headers = {
                method:'put',
                body:JSON.stringify(body)
            }
    
            fetch(`https://wildwest-1100d.firebaseio.com/players/${obj.id}.json`, headers)
            .then(re => {
                clearInterval(canvas.intervalId);
                play(obj.id)
            })
        }
        else{
            console.log('Not enough money')
        } 
    }

    return {
        save,
        reload,
        addPlayer,
        render,
        deletePlayer,
        play
    }
}

const events = attachEvents()