let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

const assert = require('chai').assert;
const expect = require('chai').expect;

describe('mathEnforcer', function(){
    describe('addFive', function(){
        it('should return undefined with parameter string', function(){
            assert.equal(mathEnforcer.addFive('5'), undefined);
        })

        it('should return undefined with parameter boolean', function(){
            assert.equal(mathEnforcer.addFive(true), undefined);
        })

        it('should return 10 with parameter 5.01', function(){
            expect(mathEnforcer.addFive(5.01)).equal(5.01+5);
        })

        it('should return -15 with parameter -20', function(){
            assert.equal(mathEnforcer.addFive(-20), -15);
        })
    })
    
    describe('subtractTen', function(){
        it('should return undefined with parameter string', function(){
            assert.equal(mathEnforcer.subtractTen('5'), undefined);
        })

        it('should return undefined with parameter boolean', function(){
            assert.equal(mathEnforcer.subtractTen(true), undefined);
        })

        it('should return 10.001-10 with parameter 10.001', function(){
            expect(mathEnforcer.subtractTen(10.001)).equal(10.001-10)
        })

        it('should return -15.001 with parameter -5', function(){
            expect(mathEnforcer.subtractTen(-15.001)).equal(-15.001-10)
        })
    })
    
    describe('sum', function(){
        it('should return undefined with parameters string', function(){
            assert.equal(mathEnforcer.sum('5', 'f'), undefined);
        })

        it('should return undefined with first parameter string', function(){
            assert.equal(mathEnforcer.sum('5', 4.5), undefined);
        })

        it('should return undefined with second parameter string', function(){
            assert.equal(mathEnforcer.sum(5, '4.5'), undefined);
        })

        it('should return undefined with parameters boolean', function(){
            assert.equal(mathEnforcer.sum(false, true), undefined);
        })

        it('should return 130.59 with second parameters 45.36, 85.23', function(){
            assert.equal(mathEnforcer.sum(45.36, 85.23), 130.59);
        })
    })
})
