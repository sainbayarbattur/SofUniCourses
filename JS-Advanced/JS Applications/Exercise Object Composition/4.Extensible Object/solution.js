function main(){
    let obj = {
        extend: function(template){
            Object.keys(template).forEach(k => {
                Object.getPrototypeOf(obj)[k] = template[k]
                obj[k] = template[k]
            })
        }
    }

    return obj
}

let ma = main()

ma.extend({
    health: 100,
    mana: 50
})

console.log(ma.hasOwnProperty('health'))