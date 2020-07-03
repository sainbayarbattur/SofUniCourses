function solve() {
    let id = 'depot'
    const arriveButton = document.getElementById('arrive')
    const departButton = document.getElementById('depart')
    const info = document.getElementsByClassName('info')[0]
    let url = `http://127.0.0.1:5500/databases/busSchedule.json`

    function depart() {
        fetch(url)
        .then(d => d.json())
        .then(d => {
            info.innerHTML = `Next stop ${d[`schedule`][id].name}` 
        })
        .catch(() => {info.innerHTM = 'Error'; arriveButton.disabled = false; departButton.disabled = false})

        arriveButton.disabled = false
        departButton.disabled = true
    }

    function arrive() {
        fetch(url)
        .then(d => d.json())
        .then(d => {
            info.innerHTML = `Arriving at ${d[`schedule`][id].name}`
            id = d[`schedule`][id].next
        })
        .catch(() => {info.innerHTM = 'Error'; arriveButton.disabled = false; departButton.disabled = false})

        departButton.disabled = false
        arriveButton.disabled = true
    }

    return {
        depart,
        arrive
    };
}

let result = solve();