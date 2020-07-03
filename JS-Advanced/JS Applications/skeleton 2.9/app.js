import get from './services/get.js'
import post from './services/post.js'
import crud from './services/crud.js'

var app = Sammy('#main', function () {
    this.use('Handlebars', 'hbs');

    this.get('#/', get.home);
    this.get('#/home', get.home);
    this.get('#/register', get.register);
    this.post('#/register', post.register);
    this.get('#/login', get.login);
    this.post('#/login', post.login);
    this.get('#/logout', get.logout);

    this.get('#/create', crud.get().create);
    this.post('#/create', false)
    this.get('#/all', crud.get().all);
    this.get('#/details/:_id', crud.get().details)
    this.get('#/delete/:_id', crud.get().deleteFunc)
    this.get('#/edit/:_id', crud.get().edit)
});

(() => {
    app.run('#/');
})()