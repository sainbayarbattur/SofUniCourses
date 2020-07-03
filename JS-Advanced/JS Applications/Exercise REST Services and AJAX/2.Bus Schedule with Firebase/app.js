function solve() {
    let id = 'depot'
    const arriveButton = document.getElementById('arrive')
    const departButton = document.getElementById('depart')
    const info = document.getElementsByClassName('info')[0]
    let url = `https://augmented-path-230517.firebaseio.com/schedule/${id}.json`

    function depart() {
        fetch(url)
        .then(d => d.json())
        .then(d => {
            info.innerHTML = `Next stop ${d.name}` 
            id = d.next
        })
        .catch(() => {info.innerHTM = 'Error'; arriveButton.disabled = false; departButton.disabled = false})

        arriveButton.disabled = false
        departButton.disabled = true
    }

    function arrive() {
        fetch(url)
        .then(d => d.json())
        .then(d => {
            info.innerHTML = `Arriving at ${d.name}`
            url = `https://augmented-path-230517.firebaseio.com/schedule/${id}.json`
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