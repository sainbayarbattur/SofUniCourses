import { exportMonkeys } from './monkeys.js'

(function(){
    fetch(`http://127.0.0.1:5500/handlebars-template.hbs`)
    .then(d => d.text())
    .then(d => {
        let obj = {
            monkeys:exportMonkeys
        }

        const monkeyTamplate = Handlebars.compile(d)

        const monkeys = monkeyTamplate(obj)

        document.getElementsByClassName('monkeys')[0].innerHTML = monkeys

        Array.from(document.getElementsByClassName('monkey')).map(m => m.getElementsByTagName('button')[0].addEventListener('click', function(e){
            e.preventDefault()

            if (e.path[1].children[3].style.display === 'none') {
                e.path[1].children[3].style.display = 'block'
                e.target.innerHTML = 'Hide'
            }
            else if (e.path[1].children[3].style.display === 'block') {
                e.path[1].children[3].style.display = 'none'
                e.target.innerHTML = 'Info'
            }
        }))
    })
})()