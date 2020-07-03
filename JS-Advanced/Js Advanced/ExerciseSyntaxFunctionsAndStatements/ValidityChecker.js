function Check(array){

    var pointA = {x:array[0], y:array[1]};

    var pointB = {x:array[2], y:array[3]};

    var mainipulationValuesA = [pointA, pointB, pointA];

    var mainipulationValuesB = [{x:0, y:0}, {x:0, y:0}, pointB];

    var resultValueValid = ['{ax, ay} to {0, 0} is valid', '{bx, by} to {0, 0} is valid', '{ax, ay} to {bx, by} is valid']

    var resultValueInvalid = ['{ax, ay} to {0, 0} is invalid', '{bx, by} to {0, 0} is invalid', '{ax, ay} to {bx, by} is invalid']

    for (let index = 0; index < 3; index++) {

        var pointC = {x:mainipulationValuesB[index].x, y:mainipulationValuesA[index].y}

        let a = mainipulationValuesA[index].x - pointC.x;

        let b = mainipulationValuesB[index].y - pointC.y;

        let distance = Math.sqrt((a*a) + (b*b));

        if (distance % 1 == 0) {
            console.log(resultValueValid[index].replace('ax', pointA.x).replace('ay', pointA.y).replace('bx', pointB.x).replace('by', pointB.y))
        }
        else{
            console.log(resultValueInvalid[index].replace('ax', pointA.x).replace('ay', pointA.y).replace('bx', pointB.x).replace('by', pointB.y))
        }
    }
}

Check([2, 1, 1, 1]);