class StringBuilder {
    constructor(string) {
      if (string !== undefined) {
        StringBuilder._vrfyParam(string);
        this._stringArray = Array.from(string);
      } else {
        this._stringArray = [];
      }
    }
  
    append(string) {
      StringBuilder._vrfyParam(string);
      for(let i = 0; i < string.length; i++) {
        this._stringArray.push(string[i]);
      }
    }
  
    prepend(string) {
      StringBuilder._vrfyParam(string);
      for(let i = string.length - 1; i >= 0; i--) {
        this._stringArray.unshift(string[i]);
      }
    }
  
    insertAt(string, startIndex) {
      StringBuilder._vrfyParam(string);
      this._stringArray.splice(startIndex, 0, ...string);
    }
  
    remove(startIndex, length) {
      this._stringArray.splice(startIndex, length);
    }
  
    static _vrfyParam(param) {
      if (typeof param !== 'string') throw new TypeError('Argument must be string');
    }
  
    toString() {
      return this._stringArray.join('');
    }
}

let f = new StringBuilder('12345');

f.remove(0, -6);

console.log(f.toString());

const expect = require('chai').expect;
const assert = require('chai').assert;

describe('StringBuilder', function(){
    describe('append', function(){
        it('should return abcde with parameters abcde', function(){
          let stringBuilder = new StringBuilder('abc');

          stringBuilder.append('de');

          expect(stringBuilder.toString()).to.equal('abcde');
        })
  })

    describe('prepend', function(){
        it('should return abcde with parameters abc', function(){
          let stringBuilder = new StringBuilder('de');
          stringBuilder.prepend('abc');
          expect(stringBuilder.toString()).to.equal('abcde')
        })
  })

    describe('insertAt', function(){
      it('should return length ab1cde with parameter abcde', function(){
         let stringBuilder = new StringBuilder('abcde');

         stringBuilder.insertAt('1234', 2);

         assert.deepEqual(stringBuilder._stringArray, ['a','b','1','2','3','4','c','d','e']);
      })

  })

    describe('remove', function(){
      it('should return length abde with parameter abcfde', function(){
        let stringBuilder = new StringBuilder('abcfde');
        stringBuilder.remove(0, 3);
        expect(stringBuilder.toString()).to.equal('fde');
      })
  })

  describe('_vrfyParam', function(){
    it('should throw exep with parameter 234', function(){
         assert.throws(function() {StringBuilder._vrfyParam(234) }, TypeError, 'Argument must be string');
    })
  })
})