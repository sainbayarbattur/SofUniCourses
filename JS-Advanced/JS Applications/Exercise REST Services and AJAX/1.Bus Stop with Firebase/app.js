function getInfo() {
    const id = document.getElementById("stopId").value;
    const stopName = document.getElementById("stopName");
    const busesData = document.getElementById("buses");

    document.getElementById("stopName").textContent = "";
    document.getElementById("buses").innerHTML = "";

    const url = `https://augmented-path-230517.firebaseio.com/businfo/${id}.json`

    fetch(url)
        .then(resources => resources.json())
        .then((data) => {
            stopName.textContent = data.name;

            if (!data.buses) {
                stopName.textContent = "Error"
            }

            for (const busId in data.buses) {
                const li = document.createElement('li')
                li.innerHTML = `Bus ${busId} arrives in ${data.buses[busId]}`
                busesData.appendChild(li)
            }
        })
}