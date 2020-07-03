let f = (function(){
    let sum = 0;

    return function a(arg){
        sum+=arg;
        a.toString = function(){return sum};
        return a;
    }
})()

console.log(f(1)(2));