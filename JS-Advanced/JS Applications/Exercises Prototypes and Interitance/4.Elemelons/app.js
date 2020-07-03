function main() {
    class Melon{
        constructor(weight, melonSort) {
            if (new.target === Melon) {
                throw new TypeError("Abstract class cannot be instantiated directly");
            }
    
            this.weight = weight
            this.melonSort = melonSort
        }
    
        toString(){
            let str = `Element: ${this.constructor.name.substring(0, this.constructor.name.length - 5)}\n`
            str += `Sort: ${this.melonSort}\n`
            str += `Element Index: ${this.elementIndex}`
            return str
        }
    }
    
    class Watermelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort)
            this._elementIndex = weight * melonSort.length
        }
    
        get elementIndex(){
            return this._elementIndex
        }
    }
    
    class Firemelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort)
            this._elementIndex = weight * melonSort.length
        }
    
        get elementIndex(){
            return this._elementIndex
        }
    }
    
    class Earthmelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort)
            this._elementIndex = weight * melonSort.length
        }
    
        get elementIndex(){
            return this._elementIndex
        }
    }
    
    class Airmelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort)
            this._elementIndex = weight * melonSort.length
        }
    
        get elementIndex(){
            return this._elementIndex
        }
    }

    class Melolemonmelon extends Watermelon{
        constructor(weight, melonSort){
            super(weight, melonSort)
            this.currEle = 'Water'
            this.elements = ['Fire', 'Earth', 'Air', 'Water']
        }

        morph(){
            let firstEle = this.elements.shift()
            this.currEle = firstEle
            this.elements.push(firstEle)
        }

        toString(){
            let str = `Element: ${this.currEle}\n`
            str += `Sort: ${this.melonSort}\n`
            str += `Element Index: ${this.elementIndex}`
            return str
        }
    }

    return {Melon, Watermelon, Firemelon, Earthmelon, Airmelon, Melolemonmelon}
}

let obj = main()

let melolemonmelon = new obj.Melolemonmelon(150, "Melo")
console.log(melolemonmelon.toString())