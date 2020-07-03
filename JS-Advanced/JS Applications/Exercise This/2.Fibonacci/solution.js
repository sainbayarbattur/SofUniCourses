function getFibonator(){
   var a = 1, b = 0, temp;

   return function getFibonator(){
      temp = a;
      a = a + b;
      b = temp;
      return b
   }
}