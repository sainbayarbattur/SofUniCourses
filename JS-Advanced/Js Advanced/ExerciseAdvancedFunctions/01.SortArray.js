function Sort(array, orderBy){

    if (orderBy == 'desc') {

        return array.sort((a, b) => b - a);   
    }

    return array.sort((a, b) => a - b);   
}

console.log(Sort([14, 7, 17, 6, 8], 'desc'));