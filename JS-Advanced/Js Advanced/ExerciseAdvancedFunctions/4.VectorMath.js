let a = (function() {

    return {

        add: function (arr1, arr2) {
        
            return [arr1[0] + arr2[0], arr1[1] + arr2[1]]
        },
    
        multiply: function (arr1, number) {
            
            return [arr1[0] * number, arr1[1] * number]
        },
    
        length: function (arr1) {
            
            return Math.sqrt(arr1[0] * arr1[0] + (arr1[1] * arr1[1]));
        },
    
        dot: function (arr1, arr2) {
            
            return arr1[0] * arr2[0] + (arr1[1] * arr2[1])
        },
    
        cross: function (arr1, arr2) {
            
            return arr1[0] * arr2[1] - (arr1[1] * arr2[0])
        }
    }

})();

console.log(a.dot([1, 0], [0, -1]));