class Hex {
   constructor(value){
      this.value = value
   }

   valueOf(){
      return this.value
   }

   toString(){
      return '0x' + this.value.toString('16').toUpperCase()
   }

   plus(hex){
      return new Hex((this.valueOf() + (hex === Number ? hex : hex.valueOf())))
   }

   minus(hex){
      return new Hex((this.valueOf() - (hex === Number ? hex : hex.valueOf())))
   }

   parse(string){
      return parseInt(string, 16)
   }
}