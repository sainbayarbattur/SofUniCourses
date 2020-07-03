class Console {

    static get placeholder() {
      return /{\d+}/g;
    }
  
    static writeLine() {
      let message = arguments[0];
      if (arguments.length === 1) {
        if (typeof (message) === 'object') {
          message = JSON.stringify(message);
          return message;
        }
        else if (typeof(message) === 'string') {
          return message;
        }
      }
      else {
        if (typeof (message) !== 'string') {
          throw new TypeError("No string format given!");
        }
        else {
          let tokens = message.match(this.placeholder).sort(function (a, b) {
            a = Number(a.substring(1, a.length - 1));
            b = Number(b.substring(1, b.length - 1));
            return a - b;
          });
          if (tokens.length !== (arguments.length - 1)) {
            throw new RangeError("Incorrect amount of parameters given!");
          }
          else {
            for (let i = 0; i < tokens.length; i++) {
              let number = Number(tokens[i].substring(1, tokens[i].length - 1));
              if (number !== i) {
                throw new RangeError("Incorrect placeholders given!");
              }
              else {
                message = message.replace(tokens[i], arguments[i + 1])
              }
            }
            return message;
          }
        }
      }
    }
}

//let d = Console.writeLine()
//console.log(d)
const assert = require('chai').assert
describe('Console', function(){
    describe('writeLine', function(){
        it('should return json', function(){
            assert.equal(Console.writeLine({name:'frgt', age:3}), '{"name":"frgt","age":3}')
        })
        it('should return json', function(){
            assert.equal(Console.writeLine('123'), '123')
        })
        it('should throw an error', function(){
            assert.throws(function() {Console.writeLine(124, 1)}, 'No string format given!')
        })
        it('should throw an error', function(){
            assert.throws(function() {Console.writeLine('12{1}4', 'vfvv', 'frfr')}, 'Incorrect amount of parameters given!')
        })
        it('should throw an error', function(){
            assert.throws(function() {Console.writeLine('frf{1}rf', 'frfrf')}, 'Incorrect placeholders given!')
        })
        it('should return a string', function(){
            assert.equal(Console.writeLine('frf{0}rf', 'pesho'), 'frfpeshorf')
        })
        it('should return a string', function(){
            assert.equal(Console.writeLine('f{3}r{2}f{1}r{0}f', 1, 2, 3, 4), 'f4r3f2r1f')
        })
        it('should return null', function(){
            assert.throws(function(){Console.writeLine('{13}', 2)}, 'Incorrect placeholders given!')
        })
    })
})
