class Stringer{
    constructor(innerString, innerLength){
        this.innerString = innerString;
        this.innerLength = innerLength;
        this.newString = this.innerString;
    }

    decrease(num){
        if (this.innerLength - num <= 0) {
            this.innerLength = 0;
            this.newString = '.'.repeat(3);
        }
        else{
            this.newString = this.newString.substring(0, this.innerLength - num);
            this.newString += '.'.repeat(this.innerLength - this.newString.length);
            this.innerLength -= num;
        }
    }

    increase(num){
        this.newString = this.innerString.substring(0, num);
        this.newString += '.'.repeat(this.newString.length - num);
        this.innerLength += num;
    }

    toString(){
        return this.newString;
    }
}