import { url, collectionName } from '../config/config.js'
import { fireBaseRequestFactory } from '../firebase/firebase-requests.js'
import { createFormEntity } from '../helpers/form-helpers.js'
import global from '../global/global.js'

const token = localStorage.getItem('token')
const firebaseRequests = fireBaseRequestFactory(url, collectionName, token)

export default (() => {
    const obj = {
        post: (context) => {
            async function create(e) {
                e.preventDefault()

                showNotification('loading', `Loading...`)

                const createForm = document.getElementById('create-form')

                let obj = global.getInfo(createFormEntity(createForm, ['cause', 'pictureUrl', 'neededFunds', 'description']).getValue())

                obj.creator = localStorage.getItem('username')

                await firebaseRequests.createEntity(obj)

                showNotification('success', 'You have succesfully created something')

                context.redirect('#/all')
            }

            return {
                create
            }
        },
        get: () => {
            async function create() {
                await global.applyCommon.call(this)

                await this.partial(`./views/forms/create-item.hbs`)

                const createForm = document.getElementById('create-form')
                
                createForm.addEventListener('submit', obj.post(this).create)
            }

            async function all() {
                await global.applyCommon.call(this)

                this.causes = Object.entries(await firebaseRequests.getAll().then(x => x || {})).map(([id, value]) => ({ _id: id, ...value }))

                this.partials.cause = await this.load(`./views/forms/cause.hbs`)

                this.partial(`./views/forms/all-items.hbs`)
            }

            async function details() {
                await global.applyCommon.call(this)

                this._id = this.params._id

                const items = await firebaseRequests.getAll()

                this.item = items[this._id]

                this.isAdmin = localStorage.getItem('username') === this.item.creator

                this.partial(`./views/forms/details.hbs`)
            }

            async function deleteFunc() {
                showNotification('loading', `Loading...`)
                firebaseRequests.deleteEntity(this.params._id)
                this.redirect('#/home')
                showNotification('success', 'You have succesfully deleted something')
            }

            async function edit() {
                showNotification('loading', `Loading...`)

                await this.partial('./views/forms/edit-form.hbs')

                showNotification('success', 'You have succesfully edited a something')
            }

            return {
                create,
                details,
                all,
                deleteFunc,
                edit
            }
        }
    }

    return obj
})()