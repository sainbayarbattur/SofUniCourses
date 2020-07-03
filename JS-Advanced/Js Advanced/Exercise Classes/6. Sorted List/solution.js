class List{
    constructor(){
        this.array = [];
        this.size = 0;
    }

    add(number){
        this.array.push(number);
        this.array.sort((a, b) => a - b);
        this.size++;
    }

    remove(index){
        if (index <= this.size - 1 && index >= 0) {
            let arrToAdd = [];
            for (let i = this.array.length - 1; i >= index; i--) {
                if (i == index) {
                    this.array.pop();
                }
                else{
                    arrToAdd.push(this.array.pop());
                }
            }
    
            arrToAdd.reverse().forEach(ad => this.array.push(ad))
            this.size--;   
        }
    }

    get(index){
        if (index >= 0 && index <= this.size - 1) {
            return this.array.sort((a, b) => a - b)[index]   
        }
    }
}
