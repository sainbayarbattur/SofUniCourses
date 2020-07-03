import { createCatalog, logIn, register, edit } from './services.js'
import { fireBaseRequestFactory } from "./firebase-requests.js" 
import { createFormEntity } from "./form-helpers.js"
import { url } from "./url.js"

/**
 * Applying header and footer
 */
export async function applyCommon(){
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    }

    this.loggedIn = !!sessionStorage.getItem('token')
    this.username = sessionStorage.getItem('username')
    this.hasNoTeam = true
}

/**
 * Applying header and footer and loading the home.hbs
 */
export async function homeViewHandler(){
    await applyCommon.call(this)

    this.partial('./templates/home/home.hbs')
}

/**
 * Applying header and footer and loading the about.hbs
 */
export async function aboutViewHandler(){
    await applyCommon.call(this)

    this.partial('./templates/about/about.hbs')
}

/**
 * Applying header and footer and gets all teams in the database, then loads the teamCatalog.hbs
 */
export async function catalogeHandler(){
    const token = sessionStorage.getItem('token')
    this.teams = Object.entries(await fireBaseRequestFactory(url, 'teams', token).getAll().then(x => x || {})).map(([id, value]) => ({ _id: id, ...value }))

    await applyCommon.call(this)
    this.partials.team = await this.load(`./templates/catalog/team.hbs`)
    await this.partial(`./templates/catalog/teamCatalog.hbs`)
}

/**
 * Applying header and footer. Also adding an event for creating a team
 */
export async function createCataloge(){
    await applyCommon.call(this)
    this.partials.createForm = await this.load(`./templates/create/createForm.hbs`)
    
    await this.partial(`./templates/create/createPage.hbs`)

    const that = this

    document.getElementById('create-form').addEventListener('submit', async function(e){
        e.preventDefault()
        createCatalog(that)
    })
}

/**
 * Applying header and footer and loading the details.hbs
 */
export async function catalogueDetailsHandler(){
    await applyCommon.call(this)
    this.partials.teamControls = await this.load(`./templates/catalog/teamControls.hbs`)
    this.partials.teamMember = await this.load(`./templates/catalog/teamMember.hbs`)

    const token = sessionStorage.getItem('token')
    const teamId = this.params.id.substring(1, this.params.id.length)
    const teams = await fireBaseRequestFactory(url, 'teams', token).getAll()

    const team = teams[teamId]

    this.name = team.name
    this.comment = team.comment
    this.members = team.members
    this.teamId = teamId

    if (team.members) {
        this.isAuthor = sessionStorage.getItem('token') === team.creator
        this.isOnTeam = team.members.map(m => m.id).includes(token)
        this.hasNoTeam = !!team   
    }

    await this.partial(`./templates/catalog/details.hbs`)
}

/**
 * Applying header and footer. Sign in user with valid authentication and loading to #/home page
 */
export async function loginHandler(){
    await applyCommon.call(this)
    this.partials.loginForm = await this.load(`./templates/login/loginForm.hbs`)

    await this.partial('./templates/login/loginPage.hbs')

    let formRef = document.getElementById('login-form')

    const that = this

    formRef.addEventListener('submit', async function(e){
        e.preventDefault()

        logIn(that, formRef)
    })
}

/**
 * Applying header and footer and also registers a person then loads the home.hbs
 */
export async function registerHandler(){
    await applyCommon.call(this)
    this.partials.registerForm = await this.load('./templates/register/registerForm.hbs')
    
    await this.partial('./templates/register/registerPage.hbs')

    let formRef = document.getElementById('register-form')

    let form = createFormEntity(formRef, ['username', 'password', 'repeatPassword'])

    const that = this

    formRef.addEventListener('submit', async function(e){
        e.preventDefault()

        register(form, that)
    })
}

/**
 * Clears sessionStorage. Signs out the person and then redirects to the #/home page
 */
export async function logoutHandler(){
    sessionStorage.clear()
    await firebase.auth().signOut()
    this.redirect([`#/home`])
}

/**
 * Joins the team with the curr id then redirects to #/catalog page
 */
export async function joinTeamHandler(){
    const teamId = this.params.id.substring(1, this.params.id.length)
    const token = sessionStorage.getItem('token')
    const teams = await fireBaseRequestFactory(url, 'teams', token).getAll()
    const team = teams[teamId]

    let person = {
        username: sessionStorage.getItem('username'),
        id: sessionStorage.getItem('token')
    }

    if (!team.members) {
        team.members = []
    }

    if (team.members.map(m => m.username).includes(sessionStorage.getItem('username'))) {
        throw new Error('You cannot join twice!')
    }

    team.members.push(person)

    await fireBaseRequestFactory(url, 'teams', token).patchEntity(team, teamId)

    this.redirect(`#/catalog`)
}

/**
 * Leaves the team with the curr id then redirects to #/catalog page
 */
export async function leaveTeamHandler(){
    const teamId = this.params.id.substring(1, this.params.id.length)
    const token = sessionStorage.getItem('token')
    const teams = await fireBaseRequestFactory(url, 'teams', token).getAll()
    const team = teams[teamId]
    const idToDelete = team.members.findIndex(m => m.id === token)

    team.members.splice(idToDelete, 1)

    await fireBaseRequestFactory(url, 'teams', token).patchEntity(team, teamId)

    this.redirect(`#/catalog`)
}

/**
 * Edits the team with the curr id then redirects to #/catalog page
 */
export async function editTeamHandler(){
    await applyCommon.call(this)

    this.partials.editForm = await this.load('./templates/edit/editForm.hbs')
    await this.partial('./templates/edit/editPage.hbs')

    const teamId = this.params.id.substring(1, this.params.id.length)
    const token = sessionStorage.getItem('token')

    const members = await fireBaseRequestFactory(url, 'teams', token).getById(teamId).members

    const form = document.getElementById('edit-form')

    const that = this

    form.addEventListener('submit',async function(e){
        e.preventDefault()

        edit(that, members)
    })
}