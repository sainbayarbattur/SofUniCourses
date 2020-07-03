function main(array, sortCri){
    class Ticket{
        constructor(destinationName, price, status){
            this.destination = destinationName;
            this.price = price
            this.status = status;
        }
    }

    let tickets = [];

    for (let i = 0; i < array.length; i++) {
        let line = array[i].split('|');

        let ticket = new Ticket(line[0], Number(line[1]), line[2]);

        tickets.push(ticket);
    }

    try {
        tickets.sort((a, b) => a[sortCri].localeCompare(b[sortCri]));   
    } catch (error) {
        tickets.sort((a, b) => a[sortCri] - b[sortCri]);   
    }

    return tickets;
}

console.log(main(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'status'
));