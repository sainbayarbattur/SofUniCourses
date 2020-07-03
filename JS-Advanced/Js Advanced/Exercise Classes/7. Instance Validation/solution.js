class CheckingAccount{
    constructor(clientId, email, firstName, lastName){
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    set clientId(value){
        if (value.length == 6 && value.match('[0-9]{6}')) {
            this.fieldClientId = value;
        }
        else{
            throw TypeError('Client ID must be a 6-digit number');
        }
    }

    set email(value){
        if (value.match('[a-zA-Z0-9]+@[A-Za-z]+.[A-Za-z]+')) {
            this.fieldEmail = value;
        }
        else{
            throw TypeError('Invalid e-mail');
        }
    }

    set firstName(value){
        let charsValid1 = value.match('[A-Za-z]+');
        let lengthValid1 = value.length >= 3 && value.length <= 20

        if (!lengthValid1) {
            throw TypeError('First name must be between 3 and 20 characters long');
        }

        if (!charsValid1) {
            throw TypeError(`First name must contain only Latin characters`);
        }

        this.fieldfirstName = value;
    }

    set lastName(value){
        
        let charsValid2 = value.match('[A-Za-z]+');
        let lengthValid2 = value.length >= 3 && value.length <= 20

        if (!lengthValid2) {
            throw TypeError('Last name must be between 3 and 20 characters long');
        }

        if (!charsValid2) {
            throw TypeError(`Last name must contain only Latin characters`);
        }

        this.fieldLastName = value;
    }
}