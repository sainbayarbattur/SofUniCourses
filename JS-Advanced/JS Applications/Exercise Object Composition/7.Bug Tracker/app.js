function main(){
    let obj = {
        bugs: [],
        id: 0,

        report(author, description, reproducible, severity){
            let div = document.createElement('div')
            let secondDiv = document.createElement('div')
            let thirdDiv = document.createElement('div')
            div.id = `report_${this.id}`
            div.className = `report`
            secondDiv.className = 'body'
            secondDiv.innerHTML = `<p>${description}</p>`
            thirdDiv.className = 'title'
            thirdDiv.innerHTML = `<span class="author">Submitted by: ${author}</span>`
            thirdDiv.innerHTML += `<span class="status">Open | ${severity}</span>`

            div.appendChild(secondDiv)
            div.appendChild(thirdDiv)
            document.getElementsByTagName('body')[0].appendChild(div)

            this.bugs.push({ ID: this.id,
                author: author,
                description: description,
                reproducible: reproducible,
                severity: severity,
                status: `Open` }
            )

            this.id++
        },

        setStatus(id, newStatus){
            let ele = document.querySelector(`#report_${id}`).getElementsByClassName('status')[0]

            let html = ele.innerHTML.split(' | ')[1]

            ele.innerHTML = newStatus + ' | ' + html
        },

        remove(id){
            let ele = document.querySelector(`#report_${id}`)
            document.getElementsByTagName('body')[0].removeChild(ele)
        },

        sort(method){
            document.getElementsByTagName('body')[0].innerHTML = ''

            this.id = 0

            if (method === 'ID') {
                
            }
            else if (method === 'severity' ) {
                
            }
            else if (method === '') {
                
            }

            this.bugs.sort((a, b) => a[method] - b[method] || a[method].localeCompare(b[method]))

            for (let i = 0; i < this.bugs.length; i++) {
                const bug = this.bugs[i];
                this.createReport(bug.author, bug.description, bug.reproducible, bug.severity, bug.ID)
            }
        },

        output(selector){
            document.getElementsByTagName('body')[0].appendChild(document.querySelector(selector))
        },

        createReport(author, description, reproducible, severity, id){
            let div = document.createElement('div')
            let secondDiv = document.createElement('div')
            let thirdDiv = document.createElement('div')
            div.id = `report_${id}`
            div.className = `report`
            secondDiv.className = 'body'
            secondDiv.innerHTML = `<p>${description}</p>`
            thirdDiv.className = 'title'
            thirdDiv.innerHTML = `<span class="author">Submitted by: ${author}</span>`
            thirdDiv.innerHTML += `<span class="status">Open | ${severity}</span>`

            div.appendChild(secondDiv)
            div.appendChild(thirdDiv)
            document.getElementsByTagName('body')[0].appendChild(div)

            this.id++
        }
    }

        // obj.report('guy', 'report content', true, 5);
        // obj.report('second guy', 'report content 2', true, 3);
        // obj.report('abv', 'report content three', true, 4);
        // obj.sort('author')
    return obj
}