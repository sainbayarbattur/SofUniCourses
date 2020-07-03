function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

const assert = require('chai').assert;

describe('lookupChar', function(){
    it('should return undefined with first parameter string', function(){
        assert.equal(lookupChar('pesho', 'gosho'), undefined);
    })

    it('should return undefined with first parameter integer', function(){
        assert.equal(lookupChar(12, 55), undefined);
    })

    it('should return undefined with second parameter not integer', function(){
        assert.equal(lookupChar('pesho', 1.1), undefined);
    })

    it('should return Incorrect index with second parameter more than string length', function(){
        assert.equal(lookupChar('pesho', 6), 'Incorrect index');
    })

    it('should return Incorrect index with second parameter equal to string length', function(){
        assert.equal(lookupChar('pesho', 5), 'Incorrect index');
    })

    it('should return Incorrect index with second parameter less than 0', function(){
        assert.equal(lookupChar('pesho', -13), 'Incorrect index');
    })

    it('should return e with first parameter qwer and second 2', function(){
        assert.equal(lookupChar('qwer', 2), 'e');
    })

    it('should return e with first parameter qwer and second 1', function(){
        assert.equal(lookupChar('qwer', 1), 'w');
    })
})