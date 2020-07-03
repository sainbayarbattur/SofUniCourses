import { fireBaseRequestFactory } from "./firebase-requests.js" 
import { createFormEntity } from "./form-helpers.js"
import { url } from "./url.js"

/**
 * Creates a catalog and then redirects to #/catalog page
 * @param that context from the invoking function
 */
export async function createCatalog(that){
    const token = sessionStorage.getItem('token')

    const firebaseTeams = await fireBaseRequestFactory(url, `teams`, token)

    const id = sessionStorage.getItem('token')
    const username = sessionStorage.getItem('username')

    let obj = {
        name: document.getElementById('name').value,
        comment: document.getElementById('comment').value,
        members: [{id, username}],
        creator:sessionStorage.getItem('token')
    }

    await firebaseTeams.createEntity(obj)

    that.redirect(`#/catalog`)
}

/**
 * Logs a person with valid token and then redirects to #/home page
 * @param that context from the invoking function
 * @param formRef login form
 */
export async function logIn(that, formRef){
    let form = createFormEntity(formRef, ['username', 'password'])
    let formValue = form.getValue()
    let obj = await firebase.auth().signInWithEmailAndPassword(formValue.username, formValue.password)

    let token = await firebase.auth().currentUser.getIdToken()
    sessionStorage.setItem('token', token)
    sessionStorage.setItem('username', obj.user.email)

    that.redirect([`#/home`])
}

/**
 * Registers a person with valid token and then redirects to #/home page
 * @param that context from the invoking function
 * @param formRef login form
 */
export async function register(form, that){
    let fromValue = form.getValue()

    if (fromValue.password !== fromValue.repeatPassword) {
        error()
        throw new Error('You passwords are not identical!')
    }

    let obj = await firebase.auth().createUserWithEmailAndPassword(fromValue.username, fromValue.password)
    let token = await firebase.auth().currentUser.getIdToken()

    sessionStorage.setItem('token', token)
    sessionStorage.setItem('username', obj.user.email)

    that.redirect([`#/home`])
}

/**
 * Edits a team with and then redirects to #/catalog page
 * @param that context from the invoking function
 * @param formRef login form
 */
export async function edit(that, members){
    let team = {
        name: document.getElementById('name').value,
        comment: document.getElementById('comment').value,
        members: members,
        creator:sessionStorage.getItem('token')
    }

    await fireBaseRequestFactory(url, 'teams', token).patchEntity(team, teamId)
    that.redirect('#/catalog')
}