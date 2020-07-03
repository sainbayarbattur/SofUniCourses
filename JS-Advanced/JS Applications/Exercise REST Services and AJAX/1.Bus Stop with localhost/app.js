function getInfo() {
    const id = document.getElementById("stopId").value;
    const stopName = document.getElementById("stopName");
    const busesData = document.getElementById("buses");

    document.getElementById("stopName").textContent = "";
    document.getElementById("buses").innerHTML = "";

    const url = `http://127.0.0.1:5500/databases/busStops.json`;

    fetch(url)
        .then(resources => resources.json())
        .then((data) => {
            stopName.textContent = data.businfo[id].name;

            if (!data.businfo) {
                stopName.textContent = "Error"
            }

            for (const busId in data.businfo[id].buses) {
                const li = document.createElement('li')
                
                li.innerHTML = `Bus ${busId} arrives in ${data.businfo[id].buses[busId]}`
                busesData.appendChild(li)
            }
        })
}