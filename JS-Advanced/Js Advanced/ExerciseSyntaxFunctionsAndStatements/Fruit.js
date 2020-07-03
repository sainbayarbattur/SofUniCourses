function Print(name, width, price){

    let widthInKilo = width / 1000;

    let priceDividedByKilo = ((widthInKilo) * price);

    console.log('I need $' + priceDividedByKilo.toFixed(2) + ' to buy ' + widthInKilo.toFixed(2) + ' kilograms ' + name + '.')
}
