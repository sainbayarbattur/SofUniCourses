(function main(){
    String.prototype.ensureStart = function(str){
        if (this.toString().split(' ')[0] != str.replace(' ', '')) {
            return this.replace (/^/,str)
        }

        return this.toString()
    }

    String.prototype.ensureEnd = function(str){
        if (this.toString().split(' ')[this.toString().split(' ').length - 1] != str.replace(' ', '')) {
            return this + str
        }

        return this.toString()
    }

    String.prototype.isEmpty = function(){
        if (this.toString() === '') {
            return true
        }

        return false
    }

    String.prototype.truncate = function(n){
        if (n < 4) {
            return '.'.repeat(n)
        }

        if (this.split(' ').length === 1) {
            return this.toString().substring(0, n - 3) + '...'
        }

        if (this.length <= n) {
            return this.toString()
        }
        else{
            return this.toString().substring(0, this.substring(0, n - 1).lastIndexOf(' ')) + '...'
        }
    }

    String['format'] = function(){
        let stringToReturn = arguments[0]
        for (let i = 0; i < arguments[0].match(/{[0-9]}/g).length; i++) {
            const placeHolder = arguments[0].match(/{[0-9]}/g)[i]

            if (arguments[i + 1] && placeHolder) {
                stringToReturn = stringToReturn.replace(placeHolder, arguments[i + 1])   
            }
        }

        return stringToReturn
    }
})()

let testString = `the quick brown fox jumps over the lazy dog`
testString = testString.truncate(10)
console.log(testString)