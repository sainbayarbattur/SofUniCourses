function Compute(first, second){

    let minNumber = Math.min(first, second);

    let result = 0

    for (let index = 1; index <= minNumber; index++) {


        if (first % index == 0
            && second % index == 0) {
            
                result = index;

                if (result == minNumber) {
                    
                    break;
                }
        }
    }

    console.log(result);
}
