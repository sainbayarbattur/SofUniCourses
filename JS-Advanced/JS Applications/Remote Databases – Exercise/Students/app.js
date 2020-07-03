function solve(){
    const body = document.getElementsByTagName('tbody')[0]

    const url = `https://students-d4d8b.firebaseio.com/students.json`

    document.getElementById('submit').addEventListener('click', async function(e){
        e.preventDefault()

        let body = {
            firstName:document.getElementById('firstName').value,
            lastName:document.getElementById('lastName').value,
            facultyNumber:document.getElementById('facultyNumber').value,
            grade:document.getElementById('grade').value,
        }

        await fetch(url, {method:'post', body:JSON.stringify(body)})

        document.getElementById('firstName').value = ''
        document.getElementById('lastName').value = ''
        document.getElementById('facultyNumber').value = ''
        document.getElementById('grade').value = ''

        load()
    })

    async function load(){
        let query = await fetch(url)
        let students = await query.json()

        body.innerHTML = ''

        let count = 1

        for (const key in students) {
            const student = students[key]

            let studentToAppend = document.createElement('tr')

            studentToAppend.innerHTML = `<td>${count}</td>` +
            `<td>${student.firstName}</td>` +
            `<td>${student.lastName}</td>` +
            `<td>${student.facultyNumber}</td>` +
            `<td>${student.grade}</td>`

            body.appendChild(studentToAppend)

            count++
        }
    }
}