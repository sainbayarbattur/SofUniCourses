import post from '../services/post.js'
import global from '../global/global.js'
import { createFormEntity } from '../helpers/form-helpers.js'

export default (function () {
    async function register() {
        await global.applyCommon.call(this)

        await this.partial('./views/register/register.hbs')

        const registerForm = document.getElementById('register-form')

        const userData = createFormEntity(registerForm, ['username', 'password', 'repeatPassword']).getValue()

        registerForm.addEventListener('submit', post(this, userData).register)
    }

    async function login() {
        await global.applyCommon.call(this)

        await this.partial('./views/login/login.hbs')

        const loginForm = document.getElementById('login-form')

        const userData = createFormEntity(loginForm, ['username', 'password']).getValue()

        loginForm.addEventListener('submit', post(this, userData).login)
    }

    async function logout() {
        await post(this).logout()
        localStorage.clear()
        this.redirect('#/home')
    }

    async function home() {
        await global.applyCommon.call(this)

        await this.partial('./views/home/home.hbs')
    }

    return {
        register,
        login,
        logout,
        home
    }
})()