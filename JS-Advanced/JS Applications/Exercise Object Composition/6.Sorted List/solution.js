function main(){
    return {
        list: [],
        size: 0,
        add: function(elemenent){
            this.list.push(elemenent)
            this.size = this.list.length
            return this.list.sort((a, b) => a - b)
        },
        remove: function(index){
            if (index >= 0 && index <= this.size - 1) {
                this.list.splice(index, 1) 
            }
            this.size = this.list.length
            return this.list.sort((a, b) => a - b)
        },
        get: function(index){
            if (index >= 0 && index <= this.size - 1) {
                return this.list[index]   
            }
        }
    }
}

let sortedList = main()
sortedList.get(1)
console.log(sortedList.size)