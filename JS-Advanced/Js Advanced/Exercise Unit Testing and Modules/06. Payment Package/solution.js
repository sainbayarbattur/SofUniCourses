class PaymentPackage {
  constructor(name, value) {
    this.name = name;
    this.value = value;
    this.VAT = 20;      // Default value    
    this.active = true; // Default value
  }

  get name() {
    return this._name;
  }

  set name(newValue) {
    if (typeof newValue !== 'string') {
      throw new Error('Name must be a non-empty string');
    }
    if (newValue.length === 0) {
      throw new Error('Name must be a non-empty string');
    }
    this._name = newValue;
  }

  get value() {
    return this._value;
  }

  set value(newValue) {
    if (typeof newValue !== 'number') {
      throw new Error('Value must be a non-negative number');
    }
    if (newValue < 0) {
      throw new Error('Value must be a non-negative number');
    }
    this._value = newValue;
  }

  get VAT() {
    return this._VAT;
  }

  set VAT(newValue) {
    if (typeof newValue !== 'number') {
      throw new Error('VAT must be a non-negative number');
    }
    if (newValue < 0) {
      throw new Error('VAT must be a non-negative number');
    }
    this._VAT = newValue;
  }

  get active() {
    return this._active;
  }

  set active(newValue) {
    if (typeof newValue !== 'boolean') {
      throw new Error('Active status must be a boolean');
    }
    this._active = newValue;
  }

  toString() {
    const output = [
      `Package: ${this.name}` + (this.active === false ? ' (inactive)' : ''),
      `- Value (excl. VAT): ${this.value}`,
      `- Value (VAT ${this.VAT}%): ${this.value * (1 + this.VAT / 100)}`
    ];
    return output.join('\n');
  }
}

const assert = require('chai').assert;

describe('PaymentPackage', function(){
  describe('name', function(){
    it('should throw error', function(){
      assert.throws(function(){new PaymentPackage('', 0)});
    })
    it('should return arg abc', function(){
      let paymentPackage = new PaymentPackage('abc', 1)
      assert.equal(paymentPackage.name, 'abc');
    })
  })

  describe('value', function(){
    it('should throw error', function(){
      assert.throws(function(){new PaymentPackage('g', -1)});
    })
    it('should return arg 1', function(){
      let paymentPackage = new PaymentPackage('abc', 1)
      assert.equal(paymentPackage.value, 1);
    })
  })

  describe('VAT', function(){
    it('should throw error', function(){
      let paymentPackage = new PaymentPackage('1', 0)
      assert.throws(function(){paymentPackage.VAT = -1});
    })
    it('should return arg 1', function(){
      let paymentPackage = new PaymentPackage('1', 0)
      paymentPackage.VAT = 1
      assert.equal(paymentPackage.VAT, 1);
    })
  })

  describe('active', function(){
    it('should throw error', function(){
      let paymentPackage = new PaymentPackage('1', 0)
      assert.throws(function(){paymentPackage.active = -1.6});
    })
    it('should return arg 1', function(){
      let paymentPackage = new PaymentPackage('1', 0)
      paymentPackage.active = true;
      assert.equal(paymentPackage.active, true);
    })
  })

  describe('toString', function(){
    it('firstLine with active true', function(){
      let paymentPackage = new PaymentPackage('f', 1);
      paymentPackage.VAT = 1;
      paymentPackage.active = true;
      assert.equal(`Package: ${paymentPackage.name}`, paymentPackage.toString().split('\n')[0]);
    })
    it('firstLine with active false', function(){
      let paymentPackage = new PaymentPackage('f', 1);
      paymentPackage.VAT = 1;
      paymentPackage.active = false;
      assert.equal(`Package: ${paymentPackage.name} (inactive)`, paymentPackage.toString().split('\n')[0]);
    })
    it('secondLine', function(){
      let paymentPackage = new PaymentPackage('f', 1);
      paymentPackage.VAT = 1;
      paymentPackage.active = false;
      assert.equal(`- Value (excl. VAT): ${paymentPackage.value}`, paymentPackage.toString().split('\n')[1]);
    })
    it('thirdLine', function(){
      let paymentPackage = new PaymentPackage('f', 1);
      paymentPackage.VAT = 1;
      paymentPackage.active = false;
      assert.equal(`- Value (VAT ${paymentPackage.VAT}%): ${paymentPackage.value * (1 + paymentPackage.VAT / 100)}`, paymentPackage.toString().split('\n')[2]);
    })
  })

  describe('constructor', function(){
    it('constructor first param', function(){
      let paymentPackage = new PaymentPackage('f', 1);
      assert.equal(paymentPackage.name, 'f');
    })
    it('constructor first param', function(){
      let paymentPackage = new PaymentPackage('f', 1);
      assert.equal(paymentPackage.value, 1);
    })
    it('constructor first param', function(){
      let paymentPackage = new PaymentPackage('f', 1);
      assert.equal(paymentPackage.VAT, 20);
    })
    it('constructor first param', function(){
      let paymentPackage = new PaymentPackage('f', 1);
      assert.equal(paymentPackage.active, true);
    })
  })
})