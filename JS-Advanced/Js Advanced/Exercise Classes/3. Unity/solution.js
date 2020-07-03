class Rat{
    constructor(name){
        this.name = name;
        this.unitedRats = [];
    }

    getRats(){
        return this.unitedRats;
    }

    unite(rat){
        let v = typeof(Object);
        if (typeof(rat) === 'object') {
            this.unitedRats.push(rat);   
        }
    }

    toString(){
        let string = this.name + '\n';
        this.unitedRats.forEach(u =>  string += '##' + u)
        return string;
    }
}