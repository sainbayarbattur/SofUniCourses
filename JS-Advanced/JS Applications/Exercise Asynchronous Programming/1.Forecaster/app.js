function attachEvents() {
    const submit = document.getElementById('submit')
    const location = document.getElementById('location')
    const url = `https://judgetests.firebaseio.com/locations`

    submit.addEventListener('click', function(e){
        e.preventDefault()
        
        document.getElementById('current').innerHTML = ''
        document.getElementById('upcoming').innerHTML = ''
        
        fetch(url + '.json')
        .then(d => d.json())
        .then(d => {
            let loc = d.find(d => d.name === location.value)

            document.getElementById('forecast').style.display = 'block'
            //today
            fetch(`https://judgetests.firebaseio.com/forecast/today/${loc.code}.json`)
            .then(d => d.json())
            .then(d => {
                let forecastDiv = todaysForecast(d)

                document.getElementById('current').appendChild(forecastDiv)
            });

            //3 days forecast
            fetch(`https://judgetests.firebaseio.com/forecast/upcoming/${loc.code}.json`)
            .then(d => d.json())
            .then(d => {
                weeeksForecast(d)
            })
        })
    })

    function todaysForecast(d){
        let forecastDiv = document.createElement('div')
        forecastDiv.className = `forecasts`

        symbolDiv = symbolGeneration(d.forecast)
        symbolDiv.className = `condition symbol`

        let conditionSpan = document.createElement('span')
        conditionSpan.className = `condition`
        //

        let nameSpan = document.createElement('span')
        nameSpan.className = 'forecast-data'
        nameSpan.innerHTML = d['name']

        let condSpan = document.createElement('span')
        condSpan.className = 'forecast-data'
        condSpan.innerHTML = d.forecast['condition']

        let tempSpan = document.createElement('span')
        tempSpan.className = 'forecast-data'
        tempSpan.innerHTML = d.forecast['low'] + `&#176;` + `/` + d.forecast['high'] + `&#176;`;

        forecastDiv.appendChild(symbolDiv)

        conditionSpan.appendChild(nameSpan)
        conditionSpan.appendChild(tempSpan)
        conditionSpan.appendChild(condSpan)

        forecastDiv.appendChild(conditionSpan)

        return forecastDiv
    }

    function weeeksForecast(d){
        for (let i = 0; i < d.forecast.length; i++) {
            const element = d.forecast[i];
            let div = document.createElement('div')
            div.className = 'forecast-info'

            let span = document.createElement('span')
            span.className = 'upcoming'

            let symbolDiv = symbolGeneration(element)

            let tempSpan = document.createElement('span')
            tempSpan.innerHTML = element['low'] + `&#176;` + `/` + element['high'] + `&#176;`;
            tempSpan.className = 'forecast-data'

            let nameSpan = document.createElement('span')
            nameSpan.innerHTML = element['condition']
            tempSpan.className = 'forecast-data'

            span.appendChild(symbolDiv)
            span.appendChild(tempSpan)
            span.appendChild(nameSpan)

            document.getElementById('upcoming').appendChild(span)
        }
    }

    function symbolGeneration(element){
        let symbolDiv = document.createElement('span')
        symbolDiv.className = `symbol`

        if (element.condition === 'Rain') {
            symbolDiv.innerHTML = '&#x2614;'
        }
        else if (element.condition === 'Sunny') {
            symbolDiv.innerHTML = '&#x2600;'  
        }
        else if (element.condition === 'Overcast') {
            symbolDiv.innerHTML = '&#x2601;'
        }
        else if (element.condition === 'Partly sunny') {
            symbolDiv.innerHTML = '&#x26C5;'
        }

        return symbolDiv
    }
}

attachEvents();