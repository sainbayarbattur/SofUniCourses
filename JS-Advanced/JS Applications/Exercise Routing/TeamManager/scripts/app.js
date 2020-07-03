import {
    homeViewHandler,
    aboutViewHandler,
    loginHandler,
    registerHandler,
    logoutHandler,
    catalogeHandler,
    createCataloge,
    catalogueDetailsHandler,
    joinTeamHandler,
    editTeamHandler,
    leaveTeamHandler
} from './handlers.js'

var app = Sammy('#main', function () {
    this.use('Handlebars', 'hbs');
    this.get('#/', homeViewHandler)
    this.get('#/home', homeViewHandler)
    this.get('#/about', aboutViewHandler)
    this.get('#/login', loginHandler)
    this.post(`#/login`, false)
    this.get('#/register', registerHandler)
    this.post('#/register', false)
    this.get('#/logout', logoutHandler)
    this.get('#/catalog', catalogeHandler)
    this.post('#/catalog', false)
    this.get(`#/create`, createCataloge)
    this.post(`#/create`, false)
    this.get('#/catalog/:id', catalogueDetailsHandler)
    this.get('#/join/:id', joinTeamHandler)
    this.post('#/join/:id', false)
    this.get('#/edit/:id', editTeamHandler)
    this.post('#/edit/:id', false)
    this.get('#/leave/:id', leaveTeamHandler)
    this.post('#/leave/:id', false)
});

(() => {
    app.run('#/');
})()