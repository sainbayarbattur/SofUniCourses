async function applyCommon() {
    this.partials = {
        header: await this.load('./views/common/header.hbs'),
        footer: await this.load('./views/common/footer.hbs')
    }

    this.isLoggedIn = !!localStorage.getItem('token')
    this.username = localStorage.getItem('username')
}

function getInfo(input) {
    let obj = {}

    Object.keys(input).map(key => obj[key] = input[key].value)

    return obj
}

export default (() => {
    return {
        applyCommon,
        getInfo
    }
})()