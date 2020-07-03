import auth from '../firebase/firebase-auth.js'

export default ((context, user) => {
    async function register(e) {
        e.preventDefault()

        showNotification('loading', `Loading...`)

        if (user.password.value !== user.repeatPassword.value) {
            showNotification('error', 'You passwords are not identical!!')
            throw new Error('You passwords are not identical!!')
        }

        await auth.createUser(user)

        let token = await auth.getCurrentUser()

        localStorage.setItem('token', token)
        localStorage.setItem('username', user.username.value)

        showNotification('success', 'You have sign up successfully!')

        context.redirect('#/home')
    }

    async function login(e) {
        e.preventDefault()

        showNotification('loading', `Loading...`)

        await auth.signIn(user)

        const token = await auth.getCurrentUser()

        localStorage.setItem('token', token)
        localStorage.setItem('username', user.username.value)

        showNotification('success', 'You have logged in successfully!')

        context.redirect('#/home')
    }

    async function logout() {
        showNotification('loading', `Loading...`)

        await auth.signOut()

        showNotification('success', 'You have logged out successfully!')
    }

    return {
        register,
        login,
        logout
    }
})