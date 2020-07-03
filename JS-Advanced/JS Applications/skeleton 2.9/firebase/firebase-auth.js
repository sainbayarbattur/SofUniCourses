export default (() => {
    return {
        createUser: (user) => {
            return firebase.auth().createUserWithEmailAndPassword(user.username.value, user.password.value)
            .catch(err => {
                showNotification('error', `${err.message}`)
                throw new Error(err.message)
            })
        },
        signIn: (user) => {
            return firebase.auth().signInWithEmailAndPassword(user.username.value, user.password.value)
                .catch(err => {
                    showNotification('error', err.message)
                    throw new Error(err.message)
                })
        },
        getCurrentUser: () => {
            return firebase.auth().currentUser.getIdToken()
            .catch(err => {
                showNotification('error', err.message)
                throw new Error(err.message)
            })
        },
        signOut: () => {
            return firebase.auth().signOut()
            .catch(err => {
                showNotification('error', err.message)
                throw new Error(err.message)
            })
        }
    }
})()