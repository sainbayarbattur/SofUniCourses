function attachEvents(){
    const submit = document.getElementById('btnLoadTowns')

    submit.addEventListener('click', function(e){     
        e.preventDefault()
        let template = Handlebars.compile(`{{#each towns}} <li>{{name}}</li> {{/each}}`)
        const townsValue = document.getElementById('towns').value
        const towns = {'towns': []}
        townsValue.split(', ').map(town => towns.towns.push({name:town}))
        console.log(template(towns))
        document.getElementsByTagName('ul')[0].innerHTML = template(towns)
    })
}